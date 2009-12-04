using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FastFingers.Forms
{
  public partial class VirtualDesktopHud : Form
  {
    public VirtualDesktopHud()
    {
      InitializeComponent();
      desktop = null;
    }

    private VirtualDesktop desktop;
    public VirtualDesktop Desktop
    {
      get
      {
        return desktop;
      }

      set
      {
        desktop = value;
        desktop_id_label.Text = desktop.Id.ToString();
        desktop_name_label.Text = desktop.Name;

        list_active_windows.Items.Clear();
        list_active_windows.SmallImageList = new ImageList();
        list_active_windows.SmallImageList.ImageSize = new Size(16, 16);
        if (desktop.Windows != null)
        {
          foreach (Window window in desktop.Windows.Values)
          {
            list_active_windows.SmallImageList.Images.Add(window.ProcessId.ToString(), window.Icon);
            list_active_windows.Items.Add(new ListViewItem(window.Title, window.ProcessId.ToString()));
          }
        }

        Update();
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        System.Windows.Forms.CreateParams p = base.CreateParams;
        p.ExStyle |= (int)Win32.ExStyles.WS_EX_TRANSPARENT;
        return p;
      }
    }

    private void FadeIn()
    {
      double op = Opacity;
      Opacity = 0.0;
      Visible = true;
      while (Opacity < op)
      {
        System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(30));
        Opacity += 0.1;
      }
      Opacity = op;
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
      Opacity = op;
      Hide();
    }

    private void fader_timer_Tick(object sender, EventArgs e)
    {
      FadeOut();
      fader_timer.Enabled = false;
    }

    public void ShowBriefly(int seconds)
    {
      fader_timer.Enabled = false;
      TopMost = true;
      Visible = true;
      fader_timer.Interval = seconds * 1000;
      fader_timer.Enabled = true;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      //e.Cancel = true;
      //Hide();
    }
  }
}