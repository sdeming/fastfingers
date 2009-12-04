using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using FastFingers.HotKeys;
using FastFingers.Controls;

namespace FastFingers.Configuration
{
  public enum Actions
  {
    // Fast
    FastExit = 100,

    // Window toggles
    ToggleSetup = 101,
    ToggleActiveWindows = 102,
    ToggleLauncher = 103,

    // Virtual desktops
    NextDesktop = 201,
    PreviousDesktop = 202,
    MoveToNextDesktop = 203,
    MoveToPreviousDesktop = 204,
    ToggleStickiness = 220,

    // Launcher
    LaunchLast = 301
  }

  public class SettingsManager
  {
    private static string application_name = "FastFingers";
    private static string data_path = "";
    private static Settings active = null;
    private static string settings_filename = "";
    private static HotKeys.HotKeyReceiver receiver = null;
    private static IntPtr handle;
    private static VirtualDesktopList desktops;

    public static IntPtr Handle
    {
      get { return handle; }
      set { handle = value; }
    }

    public static HotKeys.HotKeyReceiver Receiver
    {
      get { return receiver; }
      set { receiver = value; }
    }

    public static VirtualDesktopList Desktops
    {
      get { return desktops; }
      set { desktops = value; }
    }

    public static string ApplicationName
    {
      get { return application_name; }
    }

    public static string DataPath
    {
      get
      {
        if (data_path == "" || data_path == null)
        {
          data_path = string.Format(@"{0}\{1}",
              System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
              SettingsManager.ApplicationName);
          DirectoryInfo dir = new DirectoryInfo(data_path);
          if (!dir.Exists)
          {
            dir.Create();
          }
        }
        return data_path;
      }
    }

    public static Settings Active
    {
      get
      {
        if (active == null)
        {
          Load();
        }
        return active;
      }

    }

    public static string SettingsFilename
    {
      get
      {
        if (settings_filename == null || settings_filename == "")
        {
          settings_filename = string.Format(@"{0}\{1}", DataPath, "usersettings.xml");
        }
        return settings_filename;
      }
      set { settings_filename = value; }
    }

    public static bool Load()
    {
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(Settings));
        XmlReader reader = new XmlTextReader(new FileStream(SettingsFilename, FileMode.Open));
        active = (Settings)serializer.Deserialize(reader);
        reader.Close();

      }
      catch (FileNotFoundException)
      {
        // if we fail to load, create an instance based on default settings and save it.
        active = new Settings();
        Save();
        return false;
      }

      return true;
    }

    public static bool Save()
    {
      // ensure the directory exists for the file
      FileInfo file = new FileInfo(SettingsFilename);
      if (!file.Directory.Exists)
      {
        try
        {
          file.Directory.Create();
        }
        catch (Exception)
        {
          MessageBox.Show(string.Format("Unable to create directory: #{0}", file.Directory));
        }
        return false;
      }

      // apply limits
      Active.DesktopCount = Math.Max((short)2, Math.Min((short)Active.DesktopCount, (short)32));

      // save the data
      XmlSerializer serializer = new XmlSerializer(typeof(Settings));
      TextWriter writer = new StreamWriter(SettingsFilename);
      serializer.Serialize(writer, Active);
      writer.Close();

      return true;
    }

    public static bool Apply()
    {
      Receiver.Set(Handle, Actions.FastExit, Active.FastExitKey);
      Receiver.Set(Handle, Actions.ToggleSetup, Active.ToggleSetupWindowKey);
      Receiver.Set(Handle, Actions.ToggleLauncher, Active.ToggleLauncherKey);
      Receiver.Set(Handle, Actions.ToggleActiveWindows, Active.ToggleActiveWindowKey);
      Receiver.Set(Handle, Actions.PreviousDesktop, Active.PreviousDesktopKey);
      Receiver.Set(Handle, Actions.NextDesktop, Active.NextDesktopKey);
      Receiver.Set(Handle, Actions.MoveToNextDesktop, Active.MoveToNextDesktopKey);
      Receiver.Set(Handle, Actions.MoveToPreviousDesktop, Active.MoveToPreviousDesktopKey);
      Receiver.Set(Handle, Actions.ToggleStickiness, Active.ToggleStickinessKey);

      Desktops.Resize(Active.DesktopCount);
      return true;
    }

  }


  [Serializable]
  public class Settings
  {
    HotKeyActionDictionary hotkey_actions;
    short number_of_desktops;
    string launcher_index_filename;

    public Settings()
    {

      hotkey_actions = new HotKeyActionDictionary();

      /**
       * General Settings Defaults 
       */
      hotkey_actions[Actions.FastExit] = new KeyMask(KeyModifier.Windows, Keys.X);
      hotkey_actions[Actions.ToggleSetup] = new KeyMask(KeyModifier.Windows, Keys.Z);

      /**
       * Desktop Settings Defaults
       */
      number_of_desktops = 8;
      hotkey_actions[Actions.ToggleActiveWindows] = new KeyMask(KeyModifier.Windows, Keys.Tab);
      hotkey_actions[Actions.NextDesktop] = new KeyMask(KeyModifier.Windows, Keys.Right);
      hotkey_actions[Actions.PreviousDesktop] = new KeyMask(KeyModifier.Windows, Keys.Left);
      hotkey_actions[Actions.MoveToNextDesktop] = new KeyMask(KeyModifier.Windows, Keys.Up);
      hotkey_actions[Actions.MoveToPreviousDesktop] = new KeyMask(KeyModifier.Windows, Keys.Down);
      hotkey_actions[Actions.ToggleStickiness] = new KeyMask(KeyModifier.Windows, Keys.S);

      /**
       * Launcher Settings Defaults
       */
      launcher_index_filename = string.Format(@"{0}\{1}", SettingsManager.DataPath, "launcher_index.xml");
      hotkey_actions[Actions.ToggleLauncher] = new KeyMask(KeyModifier.Windows, Keys.Space);
      hotkey_actions[Actions.LaunchLast] = new KeyMask(KeyModifier.Windows, Keys.Escape);
    }

    /**
     * General Settings
     */
    [XmlElement(typeof(KeyMask), ElementName = "fast-exit-key"),
    CategoryAttribute("General"),
    DisplayNameAttribute("Fast exit hotkey"),
    DescriptionAttribute("Exist FastFingers immediately and close all virtual desktops."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask FastExitKey
    {
      get { return hotkey_actions[Actions.FastExit]; }
      set { hotkey_actions[Actions.FastExit] = value; }
    }


    [XmlElement(typeof(KeyMask), ElementName = "toggle-setup-window-key"),
    CategoryAttribute("General"),
    DisplayNameAttribute("Setup window hotkey"),
    DescriptionAttribute("Hotkey used to open or close the setup window."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask ToggleSetupWindowKey
    {
      get { return hotkey_actions[Actions.ToggleSetup]; }
      set { hotkey_actions[Actions.ToggleSetup] = value; }
    }



    /**
     * Virtual Desktop
     */
    [XmlElement(typeof(short), ElementName = "desktop-count"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Number of desktops"),
    DescriptionAttribute("The number of virtual desktops to create."),
    DefaultValueAttribute(8)]
    public short DesktopCount
    {
      get { return number_of_desktops; }
      set { number_of_desktops = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "toggle-active-window-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Active windows hotkey"),
    DescriptionAttribute("Hotkey to open or close the active windows window."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask ToggleActiveWindowKey
    {
      get { return hotkey_actions[Actions.ToggleActiveWindows]; }
      set { hotkey_actions[Actions.ToggleActiveWindows] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "next-desktop-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Next desktop hotkey"),
    DescriptionAttribute("Hotkey used to switch to the next desktop (or wrap to the first)."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask NextDesktopKey
    {
      get { return hotkey_actions[Actions.NextDesktop]; }
      set { hotkey_actions[Actions.NextDesktop] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "previous-desktop-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Previous desktop hotkey"),
    DescriptionAttribute("Hotkey to switch to the previous desktop (or wrap to the last)."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask PreviousDesktopKey
    {
      get { return hotkey_actions[Actions.PreviousDesktop]; }
      set { hotkey_actions[Actions.PreviousDesktop] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "move-to-next-desktop-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Move to next desktop hotkey"),
    DescriptionAttribute("Hotkey to move the current window to the next desktop."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask MoveToNextDesktopKey
    {
      get { return hotkey_actions[Actions.MoveToNextDesktop]; }
      set { hotkey_actions[Actions.MoveToNextDesktop] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "move-to-previous-desktop-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Move to previous desktop hotkey"),
    DescriptionAttribute("Hotkey to move the current window to the previous desktop."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask MoveToPreviousDesktopKey
    {
      get { return hotkey_actions[Actions.MoveToPreviousDesktop]; }
      set { hotkey_actions[Actions.MoveToPreviousDesktop] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "toggle-stickiness-key"),
    CategoryAttribute("Virtual Desktop Manager"),
    DisplayNameAttribute("Toggle stickiness hotkey"),
    DescriptionAttribute("Hotkey to toggle the stickiness of the active window."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask ToggleStickinessKey
    {
      get { return hotkey_actions[Actions.ToggleStickiness]; }
      set { hotkey_actions[Actions.ToggleStickiness] = value; }
    }


    /**
     * Launcher Settings
     */
    [XmlElement(typeof(KeyMask), ElementName = "toggle-launcher-key"),
    CategoryAttribute("Launcher"),
    DisplayNameAttribute("Toggle launcher hotkey"),
    DescriptionAttribute("Hotkey to open or close the Launcher window."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask ToggleLauncherKey
    {
      get { return hotkey_actions[Actions.ToggleLauncher]; }
      set { hotkey_actions[Actions.ToggleLauncher] = value; }
    }

    [XmlElement(typeof(KeyMask), ElementName = "launch-last-item-key"),
    CategoryAttribute("Launcher"),
    DisplayNameAttribute("Launch last command"),
    DescriptionAttribute("Hotkey to launch the last launched command."),
    EditorAttribute(typeof(HotKeyEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public KeyMask LaunchLastItemKey
    {
      get { return hotkey_actions[Actions.LaunchLast]; }
      set { hotkey_actions[Actions.LaunchLast] = value; }
    }

  }

  public class HotKeyActionDictionary : Dictionary<Actions, KeyMask>
  {
    public HotKeyActionDictionary()
    {
      foreach (Actions action in Enum.GetValues(typeof(Actions)))
      {
        Add(action, new KeyMask(KeyModifier.None, System.Windows.Forms.Keys.None));
      }
    }

    public HotKeyActionDictionary(XmlElement values)
    {
      foreach (XmlNode node in values.SelectNodes("//hotkeys"))
      {
        XmlElement e = (XmlElement)node;
        Actions action = (Actions)Enum.Parse(typeof(Actions), e.GetAttribute("action"));
        KeyMask mask = new KeyMask(ulong.Parse(e.GetAttribute("key")));
        Add(action, mask);
      }
    }
  }

}
