using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinCore.Win32
{
  // Struct to hold the bounds rectangle 
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;
  }

  [Flags()]
  public enum HookType
  {
    WH_JOURNALRECORD = 0,
    WH_JOURNALPLAYBACK = 1,
    WH_KEYBOARD = 2,
    WH_GETMESSAGE = 3,
    WH_CALLWNDPROC = 4,
    WH_CBT = 5,
    WH_SYSMSGFILTER = 6,
    WH_MOUSE = 7,
    WH_HARDWARE = 8,
    WH_DEBUG = 9,
    WH_SHELL = 10,
    WH_FOREGROUNDIDLE = 11,
    WH_CALLWNDPROCRET = 12,
    WH_KEYBOARD_LL = 13,
    WH_MOUSE_LL = 14
  }

  [Flags()]
  public enum ExStyles
  {
    WS_EX_TRANSPARENT = 0x20
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct WNDCLASSEX
  {
    public uint cbSize;
    public uint style;
    public IntPtr lpfnWndProc;
    public int cbClsExtra;
    public int cbWndExtra;
    public IntPtr hInstance;
    public IntPtr hIcon;
    public IntPtr hCursor;
    public IntPtr hbrBackground;
    public string lpszMenuName;
    public string lpszClassName;
    public IntPtr hIconSm;
  };

  public struct Constants
  {
    /// <summary>
    /// Windows Events
    /// </summary>
    public const int WM_HOTKEY = 0x312;

    /// <summary>
    /// SetWindowPos constants (dwFlags)
    /// </summary>
    public const uint SWP_NOSIZE = 0x1;
    public const uint SWP_NOMOVE = 0x2;
    public const uint SWP_SHOWWINDOW = 0x40;
    public const uint SWP_NOACTIVATE = 0x10;

    /// <summary>
    /// SetWindowPos constants (hWndInsertAfter)
    /// </summary>
    public const int HWD_NOTOPMOST = -2;
    public const int HWD_TOPMOST = -1;
    public const int HWD_TOP = 0;
    public const int HWD_BOTTOM = 1;

    /// <summary>
    /// ShowWindow constants (nCmdShow)
    /// </summary>
    public const int SW_HIDE = 0;              /// Hide the window. 
    public const int SW_MAXIMIZE = 3;          /// Maximize the window. 
    public const int SW_MINIMIZE = 6;          /// Minimize the window. 
    public const int SW_RESTORE = 9;           /// Restore the window (not maximized nor minimized). 
    public const int SW_SHOW = 5;              /// Show the window. 
    public const int SW_SHOWMAXIMIZED = 3;     /// Show the window maximized. 
    public const int SW_SHOWMINIMIZED = 2;     /// Show the window minimized. 
    public const int SW_SHOWMINNOACTIVFE = 7;  /// Show the window minimized but do not activate it. 
    public const int SW_SHOWNA = 8;            /// Show the window in its current state but do not activate it. 
    public const int SW_SHOWNOACTIVATE = 4;    /// Show the window in its most recent size and position but do not activate it. 
    public const int SW_SHOWNORMAL = 1;        /// Show the window and activate it (as usual). 

    /// <summary>
    /// AnimateWindow consants (dwFlags)
    /// </summary>
    public const uint AW_HOR_POSITIVE = 0x00000001;
    public const uint AW_HOR_NEGATIVE = 0x00000002;
    public const uint AW_VER_POSITIVE = 0x00000004;
    public const uint AW_VER_NEGATIVE = 0x00000008;
    public const uint AW_CENTER = 0x00000010;
    public const uint AW_HIDE = 0x00010000;
    public const uint AW_ACTIVATE = 0x00020000;
    public const uint AW_SLIDE = 0x00040000;
    public const uint AW_BLEND = 0x00080000;

    /// <summary>
    /// ShGetFileInfo constants
    /// </summary>
    public const uint SHGFI_ICON = 0x100;
    public const uint SHGFI_LARGEICON = 0x0;
    public const uint SHGFI_SMALLICON = 0x1;

    /// <summary>
    /// SetSysColors lpSysColor constants
    /// </summary>
    public const int COLOR_ACTIVEBORDER = 10;
    public const int COLOR_ACTIVECAPTION = 2;
    public const int COLOR_APPWORKSPACE = 12;
    public const int COLOR_BACKGROUND = 1;
    public const int COLOR_BTNFACE = 15;
    public const int COLOR_BTNHIGHLIGHT = 20;
    public const int COLOR_BTNHILIGHT = COLOR_BTNHIGHLIGHT;
    public const int COLOR_BTNSHADOW = 16;
    public const int COLOR_BTNTEXT = 18;
    public const int COLOR_CAPTIONTEXT = 9;
    public const int COLOR_DESKTOP = COLOR_BACKGROUND;
    public const int COLOR_GRADIENTACTIVECAPTION = 27;
    public const int COLOR_GRADIENTINACTIVECAPTION = 28;
    public const int COLOR_GRAYTEXT = 17;
    public const int COLOR_HIGHLIGHT = 13;
    public const int COLOR_HIGHLIGHTTEXT = 14;
    public const int COLOR_HOTLIGHT = 26;
    public const int COLOR_INACTIVEBORDER = 11;
    public const int COLOR_INACTIVECAPTION = 3;
    public const int COLOR_INACTIVECAPTIONTEXT = 19;
    public const int COLOR_INFOBK = 24;
    public const int COLOR_INFOTEXT = 23;
    public const int COLOR_MENU = 4;
    public const int COLOR_MENUTEXT = 7;
    public const int COLOR_SCROLLBAR = 0;
    public const int COLOR_WINDOW = 5;
    public const int COLOR_WINDOWFRAME = 6;
    public const int COLOR_WINDOWTEXT = 8;
    public const int COLOR_3DDKSHADOW = 21;
    public const int COLOR_3DFACE = COLOR_BTNFACE;
    public const int COLOR_3DHIGHLIGHT = COLOR_BTNHIGHLIGHT;
    public const int COLOR_3DHILIGHT = COLOR_BTNHIGHLIGHT;
    public const int COLOR_3DLIGHT = 22;
    public const int COLOR_3DSHADOW = COLOR_BTNSHADOW;

    /// <summary>
    /// Constants for GetClassLong and GetClassWord
    /// </summary>
    public const int GCL_MENUNAME = (-8);
    public const int GCW_HBRBACKGROUND = (-10);
    public const int GCL_HBRBACKGROUND = GCW_HBRBACKGROUND;
    public const int GCW_HCURSOR = (-12);
    public const int GCL_HCURSOR = GCW_HCURSOR;
    public const int GCW_HICON = (-14);
    public const int GCL_HICON = GCW_HICON;
    public const int GCW_HMODULE = (-16);
    public const int GCL_HMODULE = GCW_HMODULE;
    public const int GCW_CBWNDEXTRA = (-18);
    public const int GCL_CBWNDEXTRA = GCW_CBWNDEXTRA;
    public const int GCW_CBCLSEXTRA = (-20);
    public const int GCL_CBCLSEXTRA = GCW_CBCLSEXTRA;
    public const int GCL_WNDPROC = (-24);
    public const int GCW_STYLE = (-26);
    public const int GCL_STYLE = GCW_STYLE;
    public const int GCW_ATOM = (-32);
    public const int GCW_HICONSM = (-34);
    public const int GCL_HICONSM = GCW_HICONSM;
  }
}
