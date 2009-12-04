using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.ComponentModel;
using FastFingers.HotKeys;


namespace FastFingers.Controls
{
  public class HotKeyEditor : System.Drawing.Design.UITypeEditor
  {
    public HotKeyEditor()
    {
    }

    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
      return UITypeEditorEditStyle.DropDown;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
      if (value.GetType() != typeof(KeyMask))
      {
        return value;
      }

      IWindowsFormsEditorService e = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
      if (e == null)
      {
        return value;
      }

      Controls.HotKeyControl control = new Controls.HotKeyControl(e, (KeyMask)value);
      e.DropDownControl(control);

      // since control.KeyMask is a reference, return a new instance of the object.
      return new KeyMask(control.KeyMask.Mask);
    }

    public override bool IsDropDownResizable
    {
      get
      {
        return false;
      }
    }
  }
}
