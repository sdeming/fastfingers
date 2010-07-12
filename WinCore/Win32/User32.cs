using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinCore.Win32
{
  public static class User32
  {
    public const int GWL_ID = (-12);
    public const int GWL_STYLE = (-16);
    public const int GWL_EXSTYLE = (-20);


    // Window Styles 
    public const UInt32 WS_OVERLAPPED = 0;
    public const UInt32 WS_POPUP = 0x80000000;
    public const UInt32 WS_CHILD = 0x40000000;
    public const UInt32 WS_MINIMIZE = 0x20000000;
    public const UInt32 WS_VISIBLE = 0x10000000;
    public const UInt32 WS_DISABLED = 0x8000000;
    public const UInt32 WS_CLIPSIBLINGS = 0x4000000;
    public const UInt32 WS_CLIPCHILDREN = 0x2000000;
    public const UInt32 WS_MAXIMIZE = 0x1000000;
    public const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
    public const UInt32 WS_BORDER = 0x800000;
    public const UInt32 WS_DLGFRAME = 0x400000;
    public const UInt32 WS_VSCROLL = 0x200000;
    public const UInt32 WS_HSCROLL = 0x100000;
    public const UInt32 WS_SYSMENU = 0x80000;
    public const UInt32 WS_THICKFRAME = 0x40000;
    public const UInt32 WS_GROUP = 0x20000;
    public const UInt32 WS_TABSTOP = 0x10000;
    public const UInt32 WS_MINIMIZEBOX = 0x20000;
    public const UInt32 WS_MAXIMIZEBOX = 0x10000;
    public const UInt32 WS_TILED = WS_OVERLAPPED;
    public const UInt32 WS_ICONIC = WS_MINIMIZE;
    public const UInt32 WS_SIZEBOX = WS_THICKFRAME;

    // Extended Window Styles 
    public const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
    public const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
    public const UInt32 WS_EX_TOPMOST = 0x0008;
    public const UInt32 WS_EX_ACCEPTFILES = 0x0010;
    public const UInt32 WS_EX_TRANSPARENT = 0x0020;
    public const UInt32 WS_EX_MDICHILD = 0x0040;
    public const UInt32 WS_EX_TOOLWINDOW = 0x0080;
    public const UInt32 WS_EX_WINDOWEDGE = 0x0100;
    public const UInt32 WS_EX_CLIENTEDGE = 0x0200;
    public const UInt32 WS_EX_CONTEXTHELP = 0x0400;
    public const UInt32 WS_EX_RIGHT = 0x1000;
    public const UInt32 WS_EX_LEFT = 0x0000;
    public const UInt32 WS_EX_RTLREADING = 0x2000;
    public const UInt32 WS_EX_LTRREADING = 0x0000;
    public const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
    public const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
    public const UInt32 WS_EX_CONTROLPARENT = 0x10000;
    public const UInt32 WS_EX_STATICEDGE = 0x20000;
    public const UInt32 WS_EX_APPWINDOW = 0x40000;
    public const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
    public const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
    public const UInt32 WS_EX_LAYERED = 0x00080000;
    public const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
    public const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
    public const UInt32 WS_EX_COMPOSITED = 0x02000000;
    public const UInt32 WS_EX_NOACTIVATE = 0x08000000;

    public const UInt32 SW_HIDE = 0;
    public const UInt32 SW_SHOWNORMAL = 1;
    public const UInt32 SW_NORMAL = 1;
    public const UInt32 SW_SHOWMINIMIZED = 2;
    public const UInt32 SW_SHOWMAXIMIZED = 3;
    public const UInt32 SW_MAXIMIZE = 3;
    public const UInt32 SW_SHOWNOACTIVATE = 4;
    public const UInt32 SW_SHOW = 5;
    public const UInt32 SW_MINIMIZE = 6;
    public const UInt32 SW_SHOWMINNOACTIVE = 7;
    public const UInt32 SW_SHOWNA = 8;
    public const UInt32 SW_RESTORE = 9;

    public const UInt32 TARGETWINDOW = WS_BORDER | WS_VISIBLE;

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool RegisterHotKey(int hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnregisterHotKey(int hWnd, int id);

    public delegate bool EnumWindowsCallBack(int hWnd, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int EnumWindows(EnumWindowsCallBack x, int y);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void GetWindowText(int hWnd, StringBuilder s, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void GetWindowModuleFileName(int hWnd, StringBuilder s, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void GetClassName(int hWnd, StringBuilder s, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void GetClassInfoEx(int hInstance, string className, out Win32.WNDCLASSEX lpwcx);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr GetClassLong(int hWnd, int nIndex);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool IsWindowVisible(int hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool IsWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetShellWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetDesktopWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr FindWindow(string strClassName, string strWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, IntPtr className, string windowTitle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetSysColors(int changes, ref int lpSysColor, ref int lpColorValues);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void SwitchToThisWindow(int hWnd, bool fAltTab);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool AnimateWindow(int hWnd, uint dwTime, uint dwFlags);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool ShowWindow(int hWnd, int nCmdShow);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetWindowRect(int hWnd, ref RECT lpRect);

    [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int MoveWindow(int hWnd, int x, int y, int nWidth, int nHeight, int bRepaint);

    [DllImport("user32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowPos(int hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint dwFlags);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    #if !_WIN64
      [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
      public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
    #else
      [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
      public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
    #endif

    [DllImport("User32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);

    // Windows hook
    public delegate int WindowsHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 SetWindowsHookEx(int hook_id, WindowsHookCallback lpfn, IntPtr hInstance, int threadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(IntPtr hook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);

  } // class User32
}
