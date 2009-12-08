using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using WinCore.Win32;

namespace FastFingers.HotKeys
{
  [Flags()]
  public enum KeyModifier
  {
    None = 0,
    Alt = 1,
    Control = 2,
    Shift = 4,
    Windows = 8
  }

  [Serializable]
  public class KeyMask
  {
    private KeyModifier modifier;
    private Keys key;

    public KeyMask()
    {
      Modifier = KeyModifier.None;
      Key = Keys.None;
    }

    public KeyMask(UInt64 key_mask)
    {
      Modifier = (KeyModifier)(key_mask >> 32);
      Key = (Keys)(key_mask & 0x00000000FFFFFFFF);
    }

    public KeyMask(KeyModifier modifier, Keys key)
    {
      this.modifier = modifier;
      this.key = key;
    }

    public KeyModifier Modifier
    {
      get { return modifier; }
      set { modifier = value; }
    }

    public Keys Key
    {
      get { return key; }
      set { key = value; }
    }

    [XmlElement(typeof(UInt64), ElementName = "Mask")]
    public UInt64 Mask
    {
      get
      {
        return ((UInt64)modifier << 32) | (uint)key;
      }

      set
      {
        modifier = (KeyModifier)((value & 0xFFFFFFFF00000000) >> 32);
        key = (Keys)(value & 0x00000000FFFFFFFF);
      }
    }

    public override string ToString()
    {
      List<string> keys = new List<string>(5);

      if (modifier != KeyModifier.None)
      {
        foreach (string s in modifier.ToString().Split(','))
        {
          keys.Add(s.Trim());
        }
      }
      keys.Add(key.ToString());

      return string.Join(",", keys.ToArray());
    }
  }

  public class HotKey
  {
    private bool registered;
    private int id;
    public int Id { get { return id; } }
    private IntPtr handle;
    private KeyMask key_mask;

    public HotKey(IntPtr handle, int id, KeyMask key_mask)
    {
      this.handle = handle;
      this.id = id;
      this.key_mask = key_mask;

      Register();
    }

    private bool Register()
    {
      if (registered)
        Unregister();

      registered = User32.RegisterHotKey((int)handle, id, (uint)key_mask.Modifier, (uint)key_mask.Key);
      return registered;
    }

    private bool Unregister()
    {
      if (!registered)
        return true;

      registered = !User32.UnregisterHotKey((int)handle, id);
      return registered;
    }
  }
}
