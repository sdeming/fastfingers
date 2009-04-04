using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FastFingers.Launching
{
    public interface ILaunchable
    {
        string Name { get; }
        string FullName { get; }
        string DirName { get; }
        string BaseName { get; }
        System.Drawing.Image Preview { get; }
        string[] Actions { get; }
    } // interface ILaunchable

    public abstract class Launchable : ILaunchable
    {
        private string name;
        private string full_name;
        private FileInfo info;

        public static ILaunchable Create(FileInfo file)
        {
            if (Executable.supportsFileType(file.Extension))
            {
                return new Executable(file.FullName);
            }
            return null;
        }

        public Launchable(string full_name)
        {
            this.full_name = full_name;
            this.info = new FileInfo(full_name);
            this.name = info.Name;
        }

        public string Name { get { return name; } }
        public string FullName { get { return full_name; } }
        public string DirName { get { return info.DirectoryName; } }
        public string BaseName { get { return info.Name; } }

        // must implement Preview
        public abstract System.Drawing.Image Preview { get; }

        // must implement Actions
        public abstract string[] Actions { get; }
    } // class Launchable

}
