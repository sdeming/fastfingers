using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FastFingers.Forms
{
  public partial class ActiveWindows : Form
  {
    public ActiveWindows()
    {
      InitializeComponent();
    }

    private void ReloadWindowData(WindowDictionary windows)
    {
      windows_view.Items.Clear();
      windows_view.SmallImageList = new ImageList();
      foreach (Window window in windows.Values)
      {
        string dimensions = string.Format("{0},{1},{2},{3}",
            window.Rect.left,
            window.Rect.top,
            window.Rect.right,
            window.Rect.bottom);

        if (!windows_view.SmallImageList.Images.ContainsKey(window.ProcessId.ToString()))
        {
          windows_view.SmallImageList.Images.Add(window.ProcessId.ToString(), window.Icon);
        }

        ListViewItem item = new ListViewItem(window.Title, window.ProcessId.ToString());
        item.SubItems.Add(window.Handle.ToString());
        item.SubItems.Add(window.ProcessId.ToString());
        item.SubItems.Add(window.ModuleFilename);
        item.SubItems.Add(window.Visible ? "Yes" : "No");
        item.SubItems.Add(dimensions);
        item.SubItems.Add(window.ZOrder.ToString());
        windows_view.Items.Add(item);
      }
    }

    private void refresh_button_Click(object sender, EventArgs e)
    {
      ReloadWindowData(WindowDictionary.All);
    }

    private void refresh_visible_button_Click(object sender, EventArgs e)
    {
      ReloadWindowData(WindowDictionary.Visible);
    }

    private void toggle_button_Click(object sender, EventArgs e)
    {
      WindowDictionary windows = WindowDictionary.All;

      foreach (ListViewItem item in windows_view.CheckedItems)
      {
        int hWnd = int.Parse(item.SubItems[1].Text);
        if (windows.ContainsKey(hWnd))
        {
          windows[hWnd].Visible = !windows[hWnd].Visible;
        }
      }
    }

    private void bring_in_button_Click(object sender, EventArgs e)
    {
      WindowDictionary windows = WindowDictionary.All;
      foreach (ListViewItem item in windows_view.CheckedItems)
      {
        int hWnd = 0;
        if (int.TryParse(item.Text, out hWnd) && windows.ContainsKey(hWnd))
        {
          Window window = windows[hWnd];
          Win32.RECT rect = new Win32.RECT();
          rect.left = 0;
          rect.top = 0;
          rect.right = 0 + window.Width;
          rect.bottom = 0 + window.Height;
          window.Rect = rect;
        }
      }
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);

      e.Cancel = true;
      Hide();
    }
  }
}