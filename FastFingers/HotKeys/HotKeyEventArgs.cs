using System;
using System.Collections.Generic;
using System.Text;

namespace FastFingers.HotKeys
{
    class HotKeyEventArgs : EventArgs
    {
        private HotKey key;

        public HotKey Key
        {
            get { return key; }
        }

        public HotKeyEventArgs(HotKey key)
            : base()
        {
            this.key = key;
        }
    }
}
