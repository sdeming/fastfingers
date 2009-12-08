using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinCore.Win32
{
  public partial class Kernel32
  {
    [DllImport("kernel32", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int GetModuleHandle(string name);
  } // class Kernel32
}
