using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FastFingers.Launching;

namespace FastFingers.Forms
{
  public partial class Launcher : Form, ILauncherIndexerObserver
  {
    private LauncherIndex launch_index;
    private ILaunchable subject_launchable;
    private string launchable_name_label_default_text;
    private string launchable_entered_text;

    public Launcher()
    {
      InitializeComponent();
      launch_index = new LauncherIndex();
      launch_index.Load("launchindex.xml");
      launchable_name_label_default_text = launchable_name_label.Text;
      launchable_entered_text = "";
      SetSubject(null);
      Focus();
    }

    private void Cancel()
    {
      Hide();
    }

    private void TryLaunch()
    {
      Hide();

      try
      {
        if (subject_launchable != null)
        {
          bool results = new Launching.Execute(subject_launchable, "").DoAction();
        }
      }
      catch (Exception)
      {
        //@todo: do something here.
      }
    }

    private void Reindex()
    {
      LauncherIndexer indexer = new LauncherIndexer();
      indexer.Observers.Add(this);
      LaunchableList new_index = indexer.RebuildIndex();
      LauncherIndex index = new LauncherIndex();
    }

    private void Launcher_VisibleChanged(object sender, EventArgs e)
    {
      ClearSubject();
      launchable_entered_text = "";
      launchable_name_label.Text = "";
      launchable_name_label.Focus();
    }

    #region ILauncherIndexerObserver Members

    public void OnStart()
    {
      indexer_status_label.Text = "Indexing started...";
      indexer_status_label.Show();
      Update();
    }

    public void OnAddNewItem(string name)
    {
      indexer_status_label.Text = string.Format("Added: {0}", name);
      Update();
    }

    public void OnFinish()
    {
      indexer_status_label.Text = "";
      indexer_status_label.Hide();
      Update();
    }

    #endregion

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Cancel();
    }

    private void reindexToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Reindex();
    }

    private void Launcher_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyData)
      {
        case Keys.Escape:
          e.SuppressKeyPress = true;
          Cancel();
          break;
        case Keys.Enter:
          e.SuppressKeyPress = true;
          TryLaunch();
          break;
      }
    }

    private void Launcher_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Normal keys
      if (!Char.IsControl(e.KeyChar))
      {
        e.Handled = true;
        launchable_entered_text += e.KeyChar;
        launchable_name_label.Text = launchable_entered_text;
      }

      // Backspace
      else if (e.KeyChar == (char)Keys.Back)
      {
        if (launchable_entered_text.Length > 0)
        {
          launchable_entered_text = launchable_entered_text.Substring(0, launchable_entered_text.Length - 1);
          launchable_name_label.Text = launchable_entered_text;
        }
      }
    }

    private void SetSubject(ILaunchable launchable)
    {
      ClearSubject();
      subject_launchable = launchable;

      if (launchable != null)
      {
        subject_name_label.Text += launchable.Name;
        subject_path_label.Text += launchable.FullName;
        subject_last_accessed_label.Text += new System.IO.FileInfo(launchable.FullName).LastAccessTime.ToString();
        subject_thumbnail.Image = launchable.Preview;
      }
    }

    private void ClearSubject()
    {
      subject_name_label.Text = "";
      subject_path_label.Text = "Path: ";
      subject_last_accessed_label.Text = "Last accessed: ";
      subject_thumbnail.Image = null;
    }

    private void launchable_name_label_TextChanged(object sender, EventArgs e)
    {
      if (launchable_name_label.Text.Length == 0)
      {
        launchable_name_label.Text = launchable_name_label_default_text;
        launchable_name_label.ForeColor = Color.Red;
      }
      else
      {
        launchable_name_label.ForeColor = Color.DimGray;
      }

      // lool for matching application
      if (launchable_entered_text.Length > 0)
      {
        LaunchableList matches = launch_index.Launchables.FindByPrefix(launchable_entered_text);
        if (matches.Count > 0)
        {
          SetSubject(matches.Values[0][0]);
        }
      }
      else
      {
        ClearSubject();
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