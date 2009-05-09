using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FastFingers.Win32
{
  class User32
  {
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool RegisterHotKey(int hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnregisterHotKey(int hWnd, int id);



    public delegate bool EnumWindowsCallBack(int hWnd, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int EnumWindows(EnumWindowsCallBack x, int y);


    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetWindowThreadProcessId(int hWnd, out int processId);

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
    public static extern int GetShellWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetDesktopWindow();

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

    [DllImport("User32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int GetWindowLong(IntPtr hWnd, int Index);

    [DllImport("User32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int SetWindowLong(IntPtr hWnd, int Index, int Value);


    public delegate int WindowsHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern Int32 SetWindowsHookEx(int hook_id, WindowsHookCallback lpfn, IntPtr hInstance, int threadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(IntPtr hook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(IntPtr hook, int code, IntPtr wParam, IntPtr lParam);

  } // class User32
}
