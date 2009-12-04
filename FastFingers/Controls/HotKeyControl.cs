using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FastFingers.Controls
{
  public partial class HotKeyControl : UserControl
  {
    private HotKeys.KeyMask key_mask;
    private bool key_changed;
    private IWindowsFormsEditorService editor_service = null;


    public HotKeys.KeyMask KeyMask
    {
      get { return key_mask; }
      set
      {
        key_mask = value;

        key_text.Text = key_mask.Key.ToString();
        alt_check.Checked = (key_mask.Modifier & HotKeys.KeyModifier.Alt) != 0;
        shift_check.Checked = (key_mask.Modifier & HotKeys.KeyModifier.Shift) != 0;
        control_check.Checked = (key_mask.Modifier & HotKeys.KeyModifier.Control) != 0;
        windows_check.Checked = (key_mask.Modifier & HotKeys.KeyModifier.Windows) != 0;
      }
    }

    public HotKeyControl()
    {
      InitializeComponent();
      this.key_changed = false;
      this.KeyMask = new HotKeys.KeyMask(0, Keys.None);
      this.key_text.Focus();
    }

    public HotKeyControl(IWindowsFormsEditorService editor_service, HotKeys.KeyMask key_mask)
    {
      InitializeComponent();
      this.editor_service = editor_service;
      this.key_changed = false;
      this.KeyMask = key_mask;
      this.key_text.Focus();
    }

    protected override bool ProcessTabKey(bool forward)
    {
      return false;
    }

    protected override bool ProcessDialogKey(Keys keyData)
    {
      if (!key_changed && key_mask.Key == keyData)
      {
        return base.ProcessDialogKey(keyData);
      }
      else
      {
        key_changed = false;
      }

      return false;
    }

    private void key_text_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Shift:
        case Keys.ShiftKey:
          shift_check.Checked = !shift_check.Checked;
          break;

        case Keys.Alt:
        case Keys.Menu:
          alt_check.Checked = !alt_check.Checked;
          break;

        case Keys.LWin:
          windows_check.Checked = !windows_check.Checked;
          break;

        case Keys.ControlKey:
        case Keys.Control:
          control_check.Checked = !control_check.Checked;
          break;

        case Keys.RWin:
          //ignored
          break;

        default:
          if (key_mask.Key != e.KeyCode)
          {
            key_changed = true;
            key_mask.Key = e.KeyCode;
            key_text.Text = key_mask.Key.ToString();
          }
          break;
      }
    }

    private bool toggle_modifier(HotKeys.KeyModifier which, bool state)
    {
      if (state)
      {
        key_mask.Modifier |= which;
      }
      else
      {
        key_mask.Modifier = key_mask.Modifier & ((HotKeys.KeyModifier)0xFFFF ^ which);
      }

      return (key_mask.Modifier & which) != 0;
    }

    private void control_check_CheckStateChanged(object sender, EventArgs e)
    {
      toggle_modifier(HotKeys.KeyModifier.Control, control_check.Checked);
      key_text.Focus();
    }

    private void shift_check_CheckedChanged(object sender, EventArgs e)
    {
      toggle_modifier(HotKeys.KeyModifier.Shift, shift_check.Checked);
      key_text.Focus();
    }

    private void alt_check_CheckedChanged(object sender, EventArgs e)
    {
      toggle_modifier(HotKeys.KeyModifier.Alt, alt_check.Checked);
      key_text.Focus();
    }

    private void windows_check_CheckedChanged(object sender, EventArgs e)
    {
      toggle_modifier(HotKeys.KeyModifier.Windows, windows_check.Checked);
      key_text.Focus();
    }

    private void okay_button_Click(object sender, EventArgs e)
    {
      if (editor_service != null)
      {
        editor_service.CloseDropDown();
      }
    }
  }
}
