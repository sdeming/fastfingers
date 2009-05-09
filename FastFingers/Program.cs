using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FastFingers
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      CommandDispatcher dispatcher = new CommandDispatcher();

      try
      {
        Application.Run(dispatcher);
      }
      catch (Exception x)
      {
        dispatcher.Close();
        MessageBox.Show(x.Message, "FastFingers has encountered a critical error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
      }
    }
  }
}