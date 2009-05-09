namespace FastFingers.Forms
{
    partial class VirtualDesktopHud
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualDesktopHud));
          this.desktop_name_label = new System.Windows.Forms.Label();
          this.fader_timer = new System.Windows.Forms.Timer(this.components);
          this.border_panel = new System.Windows.Forms.Panel();
          this.list_active_windows = new System.Windows.Forms.ListView();
          this.title_panel = new System.Windows.Forms.Panel();
          this.desktop_id_label = new System.Windows.Forms.Label();
          this.border_panel.SuspendLayout();
          this.title_panel.SuspendLayout();
          this.SuspendLayout();
          // 
          // desktop_name_label
          // 
          this.desktop_name_label.BackColor = System.Drawing.Color.Transparent;
          this.desktop_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
          this.desktop_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.desktop_name_label.ForeColor = System.Drawing.SystemColors.HighlightText;
          this.desktop_name_label.Location = new System.Drawing.Point(0, 0);
          this.desktop_name_label.Name = "desktop_name_label";
          this.desktop_name_label.Size = new System.Drawing.Size(636, 46);
          this.desktop_name_label.TabIndex = 1;
          this.desktop_name_label.Text = "Active Desktop Name";
          this.desktop_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // fader_timer
          // 
          this.fader_timer.Interval = 3000;
          this.fader_timer.Tick += new System.EventHandler(this.fader_timer_Tick);
          // 
          // border_panel
          // 
          this.border_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.border_panel.Controls.Add(this.list_active_windows);
          this.border_panel.Controls.Add(this.title_panel);
          this.border_panel.Controls.Add(this.desktop_id_label);
          this.border_panel.Dock = System.Windows.Forms.DockStyle.Fill;
          this.border_panel.Location = new System.Drawing.Point(0, 0);
          this.border_panel.Name = "border_panel";
          this.border_panel.Size = new System.Drawing.Size(640, 240);
          this.border_panel.TabIndex = 8;
          // 
          // list_active_windows
          // 
          this.list_active_windows.BackColor = System.Drawing.SystemColors.Control;
          this.list_active_windows.BorderStyle = System.Windows.Forms.BorderStyle.None;
          this.list_active_windows.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this.list_active_windows.Location = new System.Drawing.Point(202, 54);
          this.list_active_windows.Name = "list_active_windows";
          this.list_active_windows.Scrollable = false;
          this.list_active_windows.ShowGroups = false;
          this.list_active_windows.Size = new System.Drawing.Size(425, 173);
          this.list_active_windows.TabIndex = 10;
          this.list_active_windows.UseCompatibleStateImageBehavior = false;
          this.list_active_windows.View = System.Windows.Forms.View.List;
          // 
          // title_panel
          // 
          this.title_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title_panel.BackgroundImage")));
          this.title_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          this.title_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.title_panel.Controls.Add(this.desktop_name_label);
          this.title_panel.Dock = System.Windows.Forms.DockStyle.Top;
          this.title_panel.Location = new System.Drawing.Point(0, 0);
          this.title_panel.Name = "title_panel";
          this.title_panel.Size = new System.Drawing.Size(638, 48);
          this.title_panel.TabIndex = 9;
          // 
          // desktop_id_label
          // 
          this.desktop_id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.desktop_id_label.Location = new System.Drawing.Point(11, 53);
          this.desktop_id_label.Name = "desktop_id_label";
          this.desktop_id_label.Size = new System.Drawing.Size(185, 174);
          this.desktop_id_label.TabIndex = 8;
          this.desktop_id_label.Text = "10";
          this.desktop_id_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // VirtualDesktopHud
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(640, 240);
          this.ControlBox = false;
          this.Controls.Add(this.border_panel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
          this.KeyPreview = true;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "VirtualDesktopHud";
          this.Opacity = 0.8;
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "FastFingersVDSwitcherHUD";
          this.border_panel.ResumeLayout(false);
          this.title_panel.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label desktop_name_label;
        private System.Windows.Forms.Timer fader_timer;
        private System.Windows.Forms.Panel border_panel;
        public System.Windows.Forms.Label desktop_id_label;
        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.ListView list_active_windows;


    }
}