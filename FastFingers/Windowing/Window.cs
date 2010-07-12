using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinCore.Win32;

namespace FastFingers
{
  public class Window
  {
    private RECT window_rect;
    private bool sticky;
    private string module_filename;
    private System.Drawing.Icon icon;

    static public Window ForegroundWindow()
    {
      IntPtr hWnd = User32.GetForegroundWindow();
      return new Window(hWnd.ToInt32(), 0);
    }

    public Window(int handle, int z_order)
    {
      int pid;
      this.Handle = handle;
      this.ZOrder = z_order;

      ThreadId = User32.GetWindowThreadProcessId((IntPtr)Handle, out pid);
      ProcessId = pid;

      this.window_rect = new RECT();
      this.sticky = false;
      this.module_filename = null;
      this.icon = null;

      var data = new StringBuilder(1024);
      User32.GetClassName(Handle, data, data.Capacity);
      this.Class = data.ToString();
    }

    /// <summary>
    /// Get the window handle.
    /// </summary>
    public int Handle { get; private set; }
    public int ZOrder { get; private set; }

    public int Left { get { return Rect.left; } }
    public int Top { get { return Rect.top; } }
    public int Right { get { return Rect.right; } }
    public int Bottom { get { return Rect.bottom; } }
    public int Width { get { return Rect.right - Rect.left; } }
    public int Height { get { return Rect.bottom - Rect.top; } }

    public int ProcessId { get; private set; }
    public int ThreadId { get; private set; }
    public string Class { get; private set; }

    public RECT Rect
    {
      get
      {
        User32.GetWindowRect(Handle, ref window_rect);
        return window_rect;
      }

      set
      {
        if (0 == User32.SetWindowPos(Handle, Constants.HWD_TOP, value.left, value.top, value.right, value.bottom, 0))
        {
          throw new Exception("Failed to position window.");
        }
      }
    }

    /// <summary>
    /// Get the window title.
    /// </summary>
    public string Title
    {
      get
      {
        var data = new StringBuilder(256);
        User32.GetWindowText(Handle, data, data.Capacity);
        return data.ToString();
      }
    }

    public System.Diagnostics.Process Process
    {
      get
      {
        return System.Diagnostics.Process.GetProcessById(ProcessId);
      }
    }

    public string ModuleFilename
    {
      get
      {
        if (module_filename == null)
        {
          try
          {
            module_filename = Process.MainModule.FileName;
          }
          catch (Exception)
          {
            module_filename = null;
          }
        }
        return module_filename ?? "<unknown>";
      }
    }

    public System.Drawing.Icon Icon
    {
      get
      {
        if (icon == null)
        {
          try
          {
            icon = System.Drawing.Icon.ExtractAssociatedIcon(ModuleFilename);
          }
          catch (Exception)
          {
            icon = System.Drawing.SystemIcons.Question;
          }
        }
        return icon;
      }
    }

    /// <summary>
    /// Get and set the visibility of the window.
    /// </summary>
    public bool Visible
    {
      get
      {
        return User32.IsWindowVisible(Handle);
      }
      set
      {
        if (value)
        {
          User32.ShowWindow(Handle, Constants.SW_SHOW);
        }
        else if (!sticky)
        {
          User32.ShowWindow(Handle, Constants.SW_HIDE);
        }
      }
    }

    public bool Foreground
    {
      get
      {
        return ((int)User32.GetForegroundWindow() == Handle);
      }

      set
      {
        if (value)
        {
          if (!Foreground)
          {
            User32.SwitchToThisWindow(Handle, true);
          }
        }
        else
        {
          User32.SwitchToThisWindow(User32.GetDesktopWindow(), true);
        }
      }
    }

    public int Style
    {
      get { return User32.GetWindowLong((IntPtr)Handle, User32.GWL_STYLE); }
    }

    public bool StillActive
    {
      get { return User32.IsWindow((IntPtr)Handle); }
    }
  } // class Window


  public class WindowDictionary : Dictionary<int, Window>
  {
    private bool EnumWindowCallBack(int hWnd, int lParam)
    {
      var z = this.Count;
      var window = new Window(hWnd, z);

      var skip = (false // window.Title.Length == 0
                  || (lParam == 1 && !window.Visible)                                                          // is not visible
                  || (lParam == 1 && ((window.Style & User32.TARGETWINDOW) != User32.TARGETWINDOW))            // is not a target window
                  || (window.Rect.right - window.Rect.left == 0 || window.Rect.bottom - window.Rect.top == 0)) // has 0 width or height
                  ;

      if (!skip)
      {
        this.Add(hWnd, window);
      }

      return true;
    }

    public static WindowDictionary Empty
    {
      get { return new WindowDictionary(); }
    }

    public static WindowDictionary All
    {
      get
      {
        WindowDictionary windows = new WindowDictionary();
        windows.Refresh(false);
        return windows;
      }
    }

    public static WindowDictionary Visible
    {
      get
      {
        WindowDictionary windows = new WindowDictionary();
        windows.Refresh(true);
        return windows;
      }
    }

    public WindowDictionary()
      : base()
    {
    }

    public void Refresh(bool visibleOnly)
    {
      Clear();
      User32.EnumWindows(this.EnumWindowCallBack, visibleOnly ? 1 : 0);
    }

    public Window ForegroundWindow
    {
      get
      {
        IntPtr h = User32.GetForegroundWindow();
        if (this.ContainsKey(h.ToInt32()))
        {
          return this[h.ToInt32()];
        }
        else
        {
          return null;
        }
      }

      set
      {
        User32.SwitchToThisWindow(value.Handle, true);
      }
    }

    public WindowDictionary StillActive
    {
      get
      {
        this.ToList().ForEach((pair) =>
        {
          if (!pair.Value.StillActive)
          {
            this.Remove(pair.Key);
          }
        });
        return this;
      }
    }
  } // class WindowDictionary
}
