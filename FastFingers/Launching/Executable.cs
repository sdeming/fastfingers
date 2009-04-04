using System;
using System.Collections.Generic;
using System.Text;

using FastFingers.Win32;

namespace FastFingers.Launching
{
    public class Executable : Launchable
    {
        public static bool supportsFileType(string extension)
        {
            return ".exe,.com,.bat,.cmd".Contains(extension.ToLower());
        }

        public Executable(string full_name)
            : base(full_name)
        {
        }

        public override System.Drawing.Image Preview
        {
            get
            {
                System.Drawing.Icon icon = Shell32.LoadIconFromModule(FullName);
                if (icon == null)
                {
                    icon = Shell32.LoadIconFromAssociation(FullName);
                }

                return icon.ToBitmap();
            }
        }

        public override string[] Actions
        {
            get
            {
                string[] list = { "Execute", "Open Explorer At", "Open Command Prompt At" };
                return list;
            }
        }
    } // class Executable
}
