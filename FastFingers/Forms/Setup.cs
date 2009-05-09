using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastFingers.Configuration;

namespace FastFingers.Forms
{
  public partial class Setup : Form
  {
    public Setup()
    {
      InitializeComponent();
      general_settings_grid.SelectedObject = SettingsManager.Active;
    }

    private void Apply()
    {
      SettingsManager.Save();
      SettingsManager.Load();
      SettingsManager.Apply();
      apply_button.Enabled = false;
    }

    private void Cancel()
    {
      SettingsManager.Load();
      SettingsManager.Apply();
      general_settings_grid.SelectedObject = SettingsManager.Active;
      Hide();
    }

    private void ok_button_Click(object sender, EventArgs e)
    {
      Apply();
      Hide();
    }

    private void apply_button_Click(object sender, EventArgs e)
    {
      Apply();
    }

    private void cancel_button_Click(object sender, EventArgs e)
    {
      Cancel();
    }

    private void general_settings_grid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      apply_button.Enabled = true;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      base.OnClosing(e);
      e.Cancel = true;
      Hide();
    }
  }
}