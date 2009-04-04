using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FastFingers.Win32
{
    class Shell32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("shell32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public extern static int ExtractIconEx(
            [MarshalAs(UnmanagedType.LPTStr)] 
            string lpszFile,       //size of the icon
            int nIconIndex,        //index of the icon 
            IntPtr[] phIconLarge,  //32x32 icon
            IntPtr[] phIconSmall,  //16x16 icon
            int nIcons);           //how many to get

        [DllImport("shell32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public static System.Drawing.Icon LoadIconFromModule(string filename)
        {
            int count = Shell32.ExtractIconEx(filename, -1, null, null, 0);
            if (count == 0)
            {
                return null;
            }

            IntPtr[] handles = new IntPtr[count];

            Shell32.ExtractIconEx(filename, 0, handles, null, count);
            return System.Drawing.Icon.FromHandle(handles[0]);
        }

        public static System.Drawing.Icon LoadIconFromAssociation(string filename)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            Shell32.SHGetFileInfo(filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Constants.SHGFI_ICON | Constants.SHGFI_LARGEICON);
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

    } // class Shell32
}
