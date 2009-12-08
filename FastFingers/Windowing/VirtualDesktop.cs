using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WinCore.Win32;

namespace FastFingers
{

  public class VirtualDesktopRule
  {
    public string Title { get; set; }
    public int Handle { get; set; }
    public int ProcessId { get; set; }
    public bool Protect { get; set; }

    public VirtualDesktopRule()
    {
      Title = "";
      Handle = 0;
      ProcessId = 0;
      Protect = true;
    }
  }

  public class VirtualDesktopRuleset : List<VirtualDesktopRule>
  {
    public VirtualDesktopRuleset()
      : base()
    {
    }

    public void Add(string title, int handle, int pid, bool protect)
    {
      Add(new VirtualDesktopRule()
      {
        Title = title,
        Handle = handle,
        ProcessId = pid,
        Protect = protect
      });
    }

    public VirtualDesktopRule Find(int handle, string title, int pid)
    {
      foreach (VirtualDesktopRule rule in this)
      {
        if (handle != 0 && rule.Handle == handle)
        {
          return rule;
        }

        if (title.Length != 0 && rule.Title.Length > 0)
        {
          Regex exp = new Regex(rule.Title);
          if (exp.Match(title).Success)
          {
            return rule;
          }
        }

        if (pid != 0 && rule.ProcessId == pid)
        {
          return rule;
        }
      }

      return null;
    }

    public bool Remove(int handle, string title, int pid)
    {
      VirtualDesktopRule rule = Find(handle, title, pid);
      if (rule == null)
      {
        return false;
      }

      if (rule.Protect)
      {
        return false;
      }

      this.Remove(rule);
      return true;
    }

    public bool MatchAny(int handle, string title, int pid)
    {
      return Find(handle, title, pid) != null;
    }

    public bool MatchAny(Window with)
    {
      return MatchAny(with.Handle, with.Title, with.ProcessId);
    }

  } // class VirtualDesktopRuleset

  public class VirtualDesktopList : List<VirtualDesktop>
  {
    private VirtualDesktopRuleset ignore_list;

    public VirtualDesktopList(int count)
      : base(count)
    {
      // create our default ignore list
      this.ignore_list = new VirtualDesktopRuleset();
      AddIgnoreRule("", User32.GetDesktopWindow(), 0, true);
      AddIgnoreRule("", User32.GetShellWindow(), 0, true);
      
      // add the start button
      var start_button_window = User32.FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xc017, "Start");
      AddIgnoreRule("", start_button_window, 0, true);

      // add the entire sidebar process
      var sidebar_process = from p in Process.GetProcesses()
                            where p.ProcessName == "sidebar" &&
                                  p.MainModule.FileName.EndsWith(@"Windows Sidebar\sidebar.exe")
                            select p;
      sidebar_process.ToList().ForEach((p) => AddIgnoreRule("", 0, p.Id, true));

      // add rocketdock
      var rocketdock_process = from p in Process.GetProcesses()
                               where p.ProcessName == "RocketDock" &&
                                     p.MainModule.FileName.EndsWith(@"\RocketDock.exe")
                               select p;
      rocketdock_process.ToList().ForEach((p) => AddIgnoreRule("", 0, p.Id, true));

      // create our virtual desktops
      for (int x = 0; x < count; x++)
      {
        this.Add(new VirtualDesktop(x, string.Format("Virtual Desktop #{0}", x)));
      }

      // always starting on first desktop
      this[0].Refresh(ignore_list);
    }

    public void Grow(int by)
    {
      int index = this.Count;
      for (int x = 0; x < by; x++)
      {
        this.Add(new VirtualDesktop(index + x, string.Format("Virtual Desktop #{0}", index + x)));
      }
    }

    public void Shrink(int by)
    {
      int start = this.Count - by;
      int end = this.Count;
      for (int x = start; x < end; x++)
      {
        this[x].Show(this.ignore_list);
      }
      this.RemoveRange(start, by);
    }

    public void Resize(int new_size)
    {
      int current_size = this.Count;
      if (new_size < current_size)
      {
        Shrink(current_size - new_size);
      }
      else
      {
        Grow(new_size - current_size);
      }
    }

    public void AddIgnoreRule(VirtualDesktopRule rule)
    {
      ignore_list.Add(rule);
    }

    public void AddIgnoreRule(string title, int handle, int pid, bool protect)
    {
      AddIgnoreRule(new VirtualDesktopRule() { Title = title, Handle = handle, ProcessId = pid, Protect = protect });
    }

    public void AddIgnoreRule(string title, IntPtr handle, int pid, bool protect)
    {
      AddIgnoreRule(new VirtualDesktopRule() { Title = title, Handle = (int)handle, ProcessId = pid, Protect = protect });
    }

    public bool RemoveIgnoreRule(VirtualDesktopRule rule)
    {
      return ignore_list.Remove(rule);
    }

    public bool RemoveIgnoreRule(string title, int handle, int pid)
    {
      return ignore_list.Remove(handle, title, pid);
    }

    public bool RemoveIgnoreRule(string title, IntPtr handle, int pid)
    {
      return RemoveIgnoreRule(title, (int)handle, pid);
    }

    public VirtualDesktopRule FindIgnoreRule(string title, int handle, int pid)
    {
      return ignore_list.Find(handle, title, pid);
    }

    public VirtualDesktopRule FindIgnoreRule(string title, IntPtr handle, int pid)
    {
      return FindIgnoreRule(title, (int)handle, pid);
    }

    public void ShowAll()
    {
      // iterate in reverse order to keep z-order of how they were hidden.
      foreach (VirtualDesktop desktop in this)
      {
        desktop.Show(ignore_list);
      }
    }

    public void Show(VirtualDesktop desktop)
    {
      desktop.Show(ignore_list);
    }

    public void Show(int index)
    {
      Show(this[index]);
    }

    public void Hide(VirtualDesktop desktop)
    {
      desktop.Hide(ignore_list);
    }

    public void Hide(int index)
    {
      Hide(this[index]);
    }

    public VirtualDesktop GetAfter(VirtualDesktop desktop)
    {
      int position = desktop.Id + 1;
      if (position >= this.Count)
      {
        position = 0;
      }

      return this[position];
    }

    public VirtualDesktop GetBefore(VirtualDesktop desktop)
    {
      int position = desktop.Id - 1;
      if (position < 0)
      {
        position = this.Count - 1;
      }

      return this[position];
    }
  } // class VirtualDesktopList

  public class VirtualDesktop
  {
    private int id;
    private string name;
    private WindowDictionary windows;
    private int desktop_handle;
    private Window last_active;

    public int Id { get { return id; } }
    public string Name { get { return name; } set { name = value; } }
    public WindowDictionary Windows { get { return windows; } }

    public VirtualDesktop(int id, string name)
    {
      this.id = id;
      this.name = name;
      this.last_active = null;
      this.desktop_handle = User32.GetDesktopWindow();
      windows = WindowDictionary.Empty;
    }

    public void Show(VirtualDesktopRuleset ignore_list)
    {
      // nothing to show
      if (windows == null)
      {
        return;
      }

      // sort the windows by z-order
      var sorted = from w in windows.Values
                   orderby w.ZOrder
                   select w;

      User32.SwitchToThisWindow(desktop_handle, false);
      foreach (var window in sorted)
      {
        window.Visible = true;
      }

      if (last_active != null)
      {
        windows.ForegroundWindow = last_active;
        last_active = null;
      }

      windows = null;
    }

    public WindowDictionary GetVisibleWindows(VirtualDesktopRuleset ignore_list)
    {
      WindowDictionary windows = WindowDictionary.Empty;

      // remove all ignored windows from the visible windows list.
      foreach (Window window in WindowDictionary.Visible.Values)
      {
        if (ignore_list == null || !ignore_list.MatchAny(window))
        {
          windows.Add(window.Handle, window);
        }
      }
      return windows;
    }

    public void Refresh(VirtualDesktopRuleset ignore_list)
    {
      this.windows = GetVisibleWindows(ignore_list);
    }

    public void Hide(VirtualDesktopRuleset ignore_list)
    {
      this.windows = GetVisibleWindows(ignore_list);
      foreach (Window window in this.windows.Values)
      {
        window.Visible = false;
      }
    }

    public void AddWindow(Window window)
    {
      if (!windows.ContainsKey(window.Handle))
      {
        windows.Add(window.Handle, window);
      }
    }

    public void RemoveWindow(Window window)
    {
      if (windows.ContainsKey(window.Handle))
      {
        windows.Remove(window.Handle);
      }
    }
  } // class VirtualDesktop
}
