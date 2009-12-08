using System;
using System.Collections.Generic;
using System.Text;
using WinCore.Win32;

namespace FastFingers
{
  public class Window
  {
    private int handle;
    private RECT window_rect;
    private bool sticky;
    private int z_order;
    private int process_id;
    private int thread_id;
    private string class_name;
    private string module_filename;
    private System.Drawing.Icon icon;

    static public Window ForegroundWindow()
    {
      IntPtr hWnd = User32.GetForegroundWindow();
      return new Window(hWnd.ToInt32(), 0);
    }

    public Window(int handle, int z_order)
    {
      this.handle = handle;
      this.z_order = z_order;
      this.thread_id = User32.GetWindowThreadProcessId((IntPtr)this.handle, out this.process_id);
      this.window_rect = new RECT();
      this.sticky = false;
      this.module_filename = null;
      this.icon = null;

      StringBuilder data = new StringBuilder(1024);
      User32.GetClassName(Handle, data, data.Capacity);
      this.class_name = data.ToString();
    }

    /// <summary>
    /// Get the window handle.
    /// </summary>
    public int Handle { get { return handle; } }

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

    public int Left
    {
      get
      {
        return Rect.left;
      }
    }

    public int Top
    {
      get
      {
        return Rect.top;
      }
    }

    public int Right
    {
      get
      {
        return Rect.right;
      }
    }

    public int Bottom
    {
      get
      {
        return Rect.bottom;
      }
    }

    public int Width
    {
      get
      {
        return Rect.right - Rect.left;
      }
    }

    public int Height
    {
      get
      {
        return Rect.bottom - Rect.top;
      }
    }

    public int ZOrder
    {
      get
      {
        return z_order;
      }
    }

    /// <summary>
    /// Get the window title.
    /// </summary>
    public string Title
    {
      get
      {
        StringBuilder data = new StringBuilder(256);
        User32.GetWindowText(Handle, data, data.Capacity);
        return data.ToString();
      }
    }

    /// <summary>
    /// Get the class name.
    /// </summary>
    public string Class
    {
      get
      {
        return this.class_name;
      }
    }

    public System.Diagnostics.Process Process
    {
      get
      {
        return System.Diagnostics.Process.GetProcessById(ProcessId);
      }
    }

    public int ProcessId
    {
      get
      {
        return this.process_id;
      }
    }

    public int ThreadId
    {
      get
      {
        return this.thread_id;
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

  } // class Window


  public class WindowDictionary : Dictionary<int, Window>
  {
    private bool EnumWindowCallBack(int hWnd, int lParam)
    {
      int z_order = this.Count;
      Window window = new Window(hWnd, z_order);
      bool skip = false;

      if (window.Title.Length == 0)
      {
        skip = true;
      }
      else if (lParam == 1 && window.Visible == false)
      {
        skip = true;
      }
      else if (window.Rect.right - window.Rect.left == 0 
        || window.Rect.bottom - window.Rect.top == 0)
      {
        skip = true;
      }

      if (!skip)
      {
        this.Add(hWnd, new Window(hWnd, z_order));
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
        User32.SwitchToThisWindow(value.Handle, false);
      }
    }
  } // class WindowDictionary
}
