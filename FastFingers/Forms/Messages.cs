using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FastFingers.Forms
{
  public partial class Messages : Form
  {
    private VirtualDesktopList desktops;

    public String Message
    {
      get
      {
        return this.label_message.Text;
      }

      set
      {
        this.label_message.Text = value;
        this.label_message.Refresh();
      }
    }

    public Messages()
    {
      InitializeComponent();
    }

    protected override CreateParams CreateParams
    {
      get
      {
        System.Windows.Forms.CreateParams p = base.CreateParams;
        p.ExStyle |= (int)WinCore.Win32.ExStyles.WS_EX_TRANSPARENT;
        return p;
      }
    }

    private void FadeOut()
    {
      double op = Opacity;
      Visible = true;
      while (Opacity > 0.0)
      {
        System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(30));
        Opacity -= 0.1;
      }
      Hide();
      Opacity = op;
      desktops.RemoveIgnoreRule("", this.Handle, 0);
    }

    private void fader_timer_Tick(object sender, EventArgs e)
    {
      FadeOut();
      fader_timer.Enabled = false;
    }

    public void ShowBriefly(int seconds, ref VirtualDesktopList desktops)
    {
      this.desktops = desktops;
      this.desktops.AddIgnoreRule("", this.Handle, 0, false);
      fader_timer.Enabled = false;
      TopMost = true;
      Visible = true;
      fader_timer.Interval = seconds * 1000;
      fader_timer.Enabled = true;
    }
  }
}