using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

using FastFingers.Configuration;
using FastFingers.HotKeys;
using FastFingers.Win32;

namespace FastFingers
{
  public partial class CommandDispatcher : Form
  {
    private Forms.Setup setup_form;
    private Forms.ActiveWindows active_windows_form;
    private Forms.Launcher launcher_form;

    private VirtualDesktopList desktops;
    private VirtualDesktop current_desktop;
    private Forms.VirtualDesktopHud vd_hud;

    public CommandDispatcher()
    {
      InitializeComponent();
      Setup();
    }

    private void Setup()
    {
      WindowState = FormWindowState.Minimized;
      Hide();

      // create our initial set of virtual desktops
      desktops = new VirtualDesktopList(1); //@todo: @config
      current_desktop = desktops[0];

      // create our forms
      setup_form = new Forms.Setup();
      setup_form.Visible = false;
      active_windows_form = new Forms.ActiveWindows();
      active_windows_form.Visible = false;
      //launcher_form = new Forms.Launcher();
      //launcher_form.Visible = false;
      vd_hud = new Forms.VirtualDesktopHud();
      vd_hud.Visible = false;
      vd_hud.Desktop = current_desktop;

      // add our forms to the desktop ignore rules
      desktops.AddIgnoreRule("", Handle, 0, true);
      desktops.AddIgnoreRule("", setup_form.Handle, 0, true);
      desktops.AddIgnoreRule("", active_windows_form.Handle, 0, true);
      //desktops.AddIgnoreRule("", launcher_form.Handle);
      desktops.AddIgnoreRule("", vd_hud.Handle, 0, true);

      // load settings
      SettingsManager.Receiver = receiver;
      SettingsManager.Handle = Handle;
      SettingsManager.Desktops = desktops;
      SettingsManager.Apply();

      vd_hud.ShowBriefly(1);//@todo: @config
    }

    private void Teardown()
    {
      desktops.ShowAll();
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
      Teardown();
      base.OnHandleDestroyed(e);
    }

    private void ToggleForm(Form form)
    {
      if (form.Visible)
      {
        form.Hide();
      }
      else
      {
        form.Show();
        form.Activate();
      }
    }

    private void ToggleSetup()
    {
      ToggleForm(setup_form);
    }

    private void ToggleActiveWindows()
    {
      ToggleForm(active_windows_form);
    }

    private void ToggleLauncherWindow()
    {
      //ToggleForm(launcher_form);
    }

    private void CommandDispatcher_Resize(object sender, EventArgs e)
    {
      WindowState = FormWindowState.Minimized;
      Hide();
    }

    #region ContextMenuEvents
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void setupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ToggleSetup();
    }

    private void activeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ToggleActiveWindows();
    }


    private void launcherToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //ToggleLauncherWindow();
    }

    #endregion

    private void NextDesktop()
    {
      vd_hud.ShowBriefly(1);//@todo: @config
      desktops.Hide(current_desktop);
      current_desktop = desktops.GetAfter(current_desktop);
      vd_hud.Desktop = current_desktop;
      desktops.Show(current_desktop);
    }

    private void MoveToNextDesktop()
    {
      Window active = Window.ForegroundWindow();
      if (active == null)
      {
        NextDesktop();
        return;
      }

      vd_hud.ShowBriefly(1);//@todo: @config
      desktops.Hide(current_desktop);
      current_desktop.RemoveWindow(active);
      current_desktop = desktops.GetAfter(current_desktop);
      current_desktop.AddWindow(active);
      vd_hud.Desktop = current_desktop;
      desktops.Show(current_desktop);
      active.Visible = true;
      active.Foreground = true;
    }

    private void PreviousDesktop()
    {
      vd_hud.ShowBriefly(1);//@todo: @config
      desktops.Hide(current_desktop);
      current_desktop = desktops.GetBefore(current_desktop);
      vd_hud.Desktop = current_desktop;
      desktops.Show(current_desktop);
    }

    private void MoveToPreviousDesktop()
    {
      Window active = Window.ForegroundWindow();
      if (active == null)
      {
        PreviousDesktop();
        return;
      }

      vd_hud.ShowBriefly(1);//@todo: @config
      desktops.Hide(current_desktop);
      current_desktop.RemoveWindow(active);
      current_desktop = desktops.GetBefore(current_desktop);
      current_desktop.AddWindow(active);
      vd_hud.Desktop = current_desktop;
      desktops.Show(current_desktop);
      active.Visible = true;
      active.Foreground = true;
    }

    private void ToggleStickiness()
    {
      Window active = Window.ForegroundWindow();
      if (active == null || active.Handle == 0)
      {
        return;
      }

      FastFingers.Forms.Messages m = new FastFingers.Forms.Messages();
      if (!desktops.RemoveIgnoreRule("", active.Handle, 0))
      {
        if (desktops.FindIgnoreRule("", active.Handle, 0) != null)
        {
          return;
        }
        desktops.AddIgnoreRule("", active.Handle, 0, false);
        m.Message = string.Format("Sticky: {0}", active.Title);
      }
      else
      {
        m.Message = string.Format("Not sticky: {0}", active.Title);
      }
      m.ShowBriefly(1, ref desktops);
      active.Foreground = true;
      active.Visible = true;
      active.Foreground = true;
    }

    private void receiver_HotKeyPressed(object sender, EventArgs e)
    {
      HotKey key = ((HotKeyEventArgs)e).Key;

      switch ((Actions)key.Id)
      {
        case Actions.FastExit:
          Close();
          break;
        case Actions.ToggleSetup:
          ToggleSetup();
          break;
        case Actions.ToggleLauncher:
          ToggleLauncherWindow();
          break;
        case Actions.ToggleActiveWindows:
          ToggleActiveWindows();
          break;
        case Actions.PreviousDesktop:
          PreviousDesktop();
          break;
        case Actions.NextDesktop:
          NextDesktop();
          break;
        case Actions.MoveToNextDesktop:
          MoveToNextDesktop();
          break;
        case Actions.MoveToPreviousDesktop:
          MoveToPreviousDesktop();
          break;
        case Actions.ToggleStickiness:
          ToggleStickiness();
          break;
      }
    }

    private void CommandDispatcher_Load(object sender, EventArgs e)
    {
      this.Visible = false;
    }
  }
}