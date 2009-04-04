using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

using FastFingers.Win32;

namespace FastFingers.HotKeys
{
    public class HotKeyReceiver : Component, IMessageFilter
    {
        private Dictionary<int, HotKey> keys;

        public HotKeyReceiver()
        {
            keys = new Dictionary<int, HotKey>();
            Application.AddMessageFilter(this);
        }

        ~HotKeyReceiver()
        {
            Application.RemoveMessageFilter(this);
        }

        public void Set(ref HotKey hotkey)
        {
            keys[hotkey.Id] = hotkey;
        }

        public void Set(IntPtr handle, Configuration.Actions id, KeyMask key_mask)
        {
            HotKey hotkey = new HotKey(handle, (int)id, key_mask);
            Set(ref hotkey);
        }

        public void Set(IntPtr handle, Configuration.Actions id, Keys key, KeyModifier modifier)
        {
            Set(handle, id, new KeyMask(modifier, key));
        }

        public event EventHandler HotKeyPressed;
        private void OnHotKeyPressed(EventArgs e)
        {
            if (HotKeyPressed != null)
                HotKeyPressed(this, e);
        }

        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case Constants.WM_HOTKEY:
                    int id = m.WParam.ToInt32();
                    if (keys.ContainsKey(id))
                    {
                        OnHotKeyPressed(new HotKeyEventArgs(keys[id]));
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
