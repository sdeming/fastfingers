namespace FastFingers
{
    partial class CommandDispatcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandDispatcher));
            this.dispatch_notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.main_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiver = new FastFingers.HotKeys.HotKeyReceiver();
            this.main_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dispatch_notify
            // 
            this.dispatch_notify.ContextMenuStrip = this.main_menu;
            this.dispatch_notify.Icon = ((System.Drawing.Icon)(resources.GetObject("dispatch_notify.Icon")));
            this.dispatch_notify.Text = "FastFingers";
            this.dispatch_notify.Visible = true;
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.launcherToolStripMenuItem,
            this.activeWindowsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(162, 98);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.setupToolStripMenuItem.Text = "&Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // launcherToolStripMenuItem
            // 
            this.launcherToolStripMenuItem.Name = "launcherToolStripMenuItem";
            this.launcherToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.launcherToolStripMenuItem.Text = "&Launcher";
            this.launcherToolStripMenuItem.Click += new System.EventHandler(this.launcherToolStripMenuItem_Click);
            // 
            // activeWindowsToolStripMenuItem
            // 
            this.activeWindowsToolStripMenuItem.Name = "activeWindowsToolStripMenuItem";
            this.activeWindowsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.activeWindowsToolStripMenuItem.Text = "Active &Windows";
            this.activeWindowsToolStripMenuItem.Click += new System.EventHandler(this.activeWindowsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // receiver
            // 
            this.receiver.HotKeyPressed += new System.EventHandler(this.receiver_HotKeyPressed);
            // 
            // CommandDispatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 133);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandDispatcher";
            this.ShowInTaskbar = false;
            this.Text = "FastFingers Dispatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.CommandDispatcher_Resize);
            this.Load += new System.EventHandler(this.CommandDispatcher_Load);
            this.main_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon dispatch_notify;
        private System.Windows.Forms.ContextMenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private HotKeys.HotKeyReceiver receiver;
        private System.Windows.Forms.ToolStripMenuItem launcherToolStripMenuItem;
    }
}