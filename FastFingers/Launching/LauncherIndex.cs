using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using FastFingers.Win32;
using FastFingers.Configuration;

namespace FastFingers.Launching
{
    public class LaunchableList : SortedList<string, List<ILaunchable>>
    {
        public void AddLaunchable(ILaunchable launchable)
        {
            if (launchable == null)
            {
                return;
            }

            if (ContainsKey(launchable.BaseName))
            {
                this[launchable.BaseName].Add(launchable);
            }
            else
            {
                List<ILaunchable> list = new List<ILaunchable>();
                list.Add(launchable);
                this.Add(launchable.BaseName, list);
            }
        }

        public void AddLaunchable(FileInfo file)
        {
            ILaunchable launchable = Launchable.Create(file);
            AddLaunchable(launchable);
        }

        public LaunchableList FindByPrefix(string prefix)
        {
            LaunchableList matches = new LaunchableList();
            foreach (KeyValuePair<string, List<ILaunchable>> item in this)
            {
                if (item.Key.ToLower().StartsWith(prefix.ToLower()))
                {
                    matches.Add(item.Key, item.Value);
                }
            }

            return matches;
        }
    } // class LaunchableList

    public class LauncherIndex
    {
        LaunchableList launchables;
        LauncherIndexer indexer;

        public LauncherIndex()
        {
            indexer = new LauncherIndexer();
            launchables = new LaunchableList();
        }

        public void Load(string filename)
        {
            string full_filename = string.Format(@"{0}\{1}", SettingsManager.DataPath, filename);
            if (!System.IO.File.Exists(full_filename))
            {
                launchables = Indexer.RebuildIndex();
                Save(filename);
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(full_filename);

            foreach (XmlElement entry in doc.GetElementsByTagName("launchable"))
            {
                try
                {
                    FileInfo file = new FileInfo(entry.InnerText);
                    launchables.AddLaunchable(file);
                }
                catch (System.IO.FileNotFoundException)
                {
                    // skip...
                }
            }
        }

        public void Save(string filename)
        {
            filename = string.Format(@"{0}\{1}", SettingsManager.DataPath, filename);
            XmlDocument doc = new XmlDocument();

            XmlElement index = doc.CreateElement("launchables");
            doc.AppendChild(index);
            foreach (List<ILaunchable> list in launchables.Values)
            {
                foreach (ILaunchable launchable in list)
                {
                    XmlElement entry = doc.CreateElement("launchable");
                    entry.InnerText = launchable.FullName;
                    index.AppendChild(entry);
                }
            }

            if (!new FileInfo(filename).Directory.Exists) {

            }
            doc.Save(filename);
        }

        public LaunchableList Launchables
        {
            get { return launchables; }
        }

        public LauncherIndexer Indexer
        {
            get { return indexer; }
        }

    } // class LauncherIndex


    public interface ILauncherIndexerObserver
    {
        void OnStart();
        void OnAddNewItem(string name);
        void OnFinish();
    }

    public class LauncherIndexer
    {
        List<ILauncherIndexerObserver> observers;
        List<string> paths;
        List<string> file_types;
        LaunchableList files;

        public LauncherIndexer()
        {
            this.observers = new List<ILauncherIndexerObserver>();
            this.files = new LaunchableList();

            // default paths
            this.paths = new List<string>();
            AddPath(string.Format(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));

            // parse the PATH environment variable and add each entry
            foreach (string entry in new SystemPath())
            {
                AddPath(entry);
            }

            // default file types
            this.file_types = new List<string>();
            file_types.Add(".exe");
            file_types.Add(".cmd");
            file_types.Add(".bat");
            file_types.Add(".com");
        }

        public LaunchableList RebuildIndex()
        {
            fireOnStart();

            foreach (string entry in paths)
            {
                DirectoryInfo dir = new DirectoryInfo(entry);
                AddFiles(files, dir);
            }

            fireOnFinish();

            return files;
        }

        private void AddFiles(LaunchableList list, DirectoryInfo dir)
        {
            try
            {
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    AddFiles(list, subdir);
                    foreach (FileInfo file in subdir.GetFiles("*", SearchOption.TopDirectoryOnly))
                    {
                        if (file_types.Contains(file.Extension))
                        {
                            list.AddLaunchable(file);
                            fireAddNewItem(file.Name);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip.
            }
        }

        private void fireOnStart()
        {
            foreach (ILauncherIndexerObserver observer in observers)
            {
                observer.OnStart();
            }
        }

        private void fireOnFinish()
        {
            foreach (ILauncherIndexerObserver observer in observers)
            {
                observer.OnFinish();
            }
        }

        private void fireAddNewItem(string name)
        {
            foreach (ILauncherIndexerObserver observer in observers)
            {
                observer.OnAddNewItem(name);
            }
        }

        public List<string> Paths
        {
            get { return paths; }
        }

        public List<ILauncherIndexerObserver> Observers
        {
            get { return observers; }
        }

        public void AddPath(string path)
        {
            List<string> remove_these = new List<string>();
            foreach (string entry in paths)
            {
                if (path.StartsWith(entry))
                {
                    return;
                }

                if (entry.StartsWith(path))
                {
                    remove_these.Add(entry);
                }
            }

            foreach (string entry in remove_these)
            {
                paths.Remove(entry);
            }

            paths.Add(path);
        }

        public void AddFileType(string type)
        {
            if (file_types.Contains(type))
            {
                return;
            }

            file_types.Add(type);
        }

    } // class LauncherIndex

}
