namespace FastFingers.Forms
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.back_panel = new System.Windows.Forms.Panel();
            this.action_panel = new System.Windows.Forms.Panel();
            this.action_thumbnail = new System.Windows.Forms.PictureBox();
            this.action_label = new System.Windows.Forms.Label();
            this.subject_panel = new System.Windows.Forms.Panel();
            this.subject_thumbnail = new System.Windows.Forms.PictureBox();
            this.subject_label = new System.Windows.Forms.Label();
            this.info_panel = new System.Windows.Forms.Panel();
            this.launchable_name_label = new System.Windows.Forms.Label();
            this.title_panel = new System.Windows.Forms.Panel();
            this.launcher_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reindexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexer_status_label = new System.Windows.Forms.Label();
            this.dialog_title_label = new System.Windows.Forms.Label();
            this.subject_name_label = new System.Windows.Forms.Label();
            this.subject_path_label = new System.Windows.Forms.Label();
            this.subject_last_accessed_label = new System.Windows.Forms.Label();
            this.action_name_label = new System.Windows.Forms.Label();
            this.back_panel.SuspendLayout();
            this.action_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.action_thumbnail)).BeginInit();
            this.subject_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subject_thumbnail)).BeginInit();
            this.info_panel.SuspendLayout();
            this.title_panel.SuspendLayout();
            this.launcher_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // back_panel
            // 
            this.back_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_panel.BackgroundImage")));
            this.back_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.back_panel.Controls.Add(this.action_panel);
            this.back_panel.Controls.Add(this.action_label);
            this.back_panel.Controls.Add(this.subject_panel);
            this.back_panel.Controls.Add(this.subject_label);
            this.back_panel.Controls.Add(this.info_panel);
            this.back_panel.Controls.Add(this.title_panel);
            this.back_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back_panel.Location = new System.Drawing.Point(0, 0);
            this.back_panel.Name = "back_panel";
            this.back_panel.Size = new System.Drawing.Size(480, 260);
            this.back_panel.TabIndex = 0;
            // 
            // action_panel
            // 
            this.action_panel.BackColor = System.Drawing.Color.Transparent;
            this.action_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.action_panel.Controls.Add(this.action_name_label);
            this.action_panel.Controls.Add(this.action_thumbnail);
            this.action_panel.Location = new System.Drawing.Point(12, 162);
            this.action_panel.Name = "action_panel";
            this.action_panel.Size = new System.Drawing.Size(455, 58);
            this.action_panel.TabIndex = 16;
            // 
            // action_thumbnail
            // 
            this.action_thumbnail.Location = new System.Drawing.Point(3, 3);
            this.action_thumbnail.Name = "action_thumbnail";
            this.action_thumbnail.Size = new System.Drawing.Size(48, 48);
            this.action_thumbnail.TabIndex = 1;
            this.action_thumbnail.TabStop = false;
            // 
            // action_label
            // 
            this.action_label.AutoSize = true;
            this.action_label.BackColor = System.Drawing.Color.Transparent;
            this.action_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.action_label.ForeColor = System.Drawing.Color.DimGray;
            this.action_label.Location = new System.Drawing.Point(9, 142);
            this.action_label.Name = "action_label";
            this.action_label.Size = new System.Drawing.Size(53, 17);
            this.action_label.TabIndex = 15;
            this.action_label.Text = "Action";
            // 
            // subject_panel
            // 
            this.subject_panel.BackColor = System.Drawing.Color.Transparent;
            this.subject_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.subject_panel.Controls.Add(this.subject_last_accessed_label);
            this.subject_panel.Controls.Add(this.subject_path_label);
            this.subject_panel.Controls.Add(this.subject_name_label);
            this.subject_panel.Controls.Add(this.subject_thumbnail);
            this.subject_panel.Location = new System.Drawing.Point(12, 76);
            this.subject_panel.Name = "subject_panel";
            this.subject_panel.Size = new System.Drawing.Size(455, 58);
            this.subject_panel.TabIndex = 14;
            // 
            // subject_thumbnail
            // 
            this.subject_thumbnail.Location = new System.Drawing.Point(3, 3);
            this.subject_thumbnail.Name = "subject_thumbnail";
            this.subject_thumbnail.Size = new System.Drawing.Size(48, 48);
            this.subject_thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.subject_thumbnail.TabIndex = 0;
            this.subject_thumbnail.TabStop = false;
            // 
            // subject_label
            // 
            this.subject_label.AutoSize = true;
            this.subject_label.BackColor = System.Drawing.Color.Transparent;
            this.subject_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subject_label.ForeColor = System.Drawing.Color.DimGray;
            this.subject_label.Location = new System.Drawing.Point(9, 56);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(62, 17);
            this.subject_label.TabIndex = 13;
            this.subject_label.Text = "Subject";
            // 
            // info_panel
            // 
            this.info_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("info_panel.BackgroundImage")));
            this.info_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info_panel.Controls.Add(this.launchable_name_label);
            this.info_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.info_panel.Location = new System.Drawing.Point(0, 226);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(478, 32);
            this.info_panel.TabIndex = 0;
            // 
            // launchable_name_label
            // 
            this.launchable_name_label.BackColor = System.Drawing.Color.Transparent;
            this.launchable_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchable_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchable_name_label.ForeColor = System.Drawing.Color.Red;
            this.launchable_name_label.Location = new System.Drawing.Point(0, 0);
            this.launchable_name_label.Name = "launchable_name_label";
            this.launchable_name_label.Size = new System.Drawing.Size(478, 32);
            this.launchable_name_label.TabIndex = 0;
            this.launchable_name_label.Text = "Begin typing the launchable name...";
            this.launchable_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.launchable_name_label.TextChanged += new System.EventHandler(this.launchable_name_label_TextChanged);
            // 
            // title_panel
            // 
            this.title_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title_panel.BackgroundImage")));
            this.title_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title_panel.ContextMenuStrip = this.launcher_menu;
            this.title_panel.Controls.Add(this.indexer_status_label);
            this.title_panel.Controls.Add(this.dialog_title_label);
            this.title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(478, 48);
            this.title_panel.TabIndex = 10;
            // 
            // launcher_menu
            // 
            this.launcher_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.reindexToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.launcher_menu.Name = "launcher_menu";
            this.launcher_menu.Size = new System.Drawing.Size(125, 76);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.executeToolStripMenuItem.Text = "E&xecute";
            // 
            // reindexToolStripMenuItem
            // 
            this.reindexToolStripMenuItem.Name = "reindexToolStripMenuItem";
            this.reindexToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.reindexToolStripMenuItem.Text = "&Reindex";
            this.reindexToolStripMenuItem.Click += new System.EventHandler(this.reindexToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // indexer_status_label
            // 
            this.indexer_status_label.BackColor = System.Drawing.Color.Transparent;
            this.indexer_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indexer_status_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.indexer_status_label.Location = new System.Drawing.Point(111, 12);
            this.indexer_status_label.Name = "indexer_status_label";
            this.indexer_status_label.Size = new System.Drawing.Size(356, 23);
            this.indexer_status_label.TabIndex = 1;
            this.indexer_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.indexer_status_label.Visible = false;
            // 
            // dialog_title_label
            // 
            this.dialog_title_label.AutoSize = true;
            this.dialog_title_label.BackColor = System.Drawing.Color.Transparent;
            this.dialog_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog_title_label.ForeColor = System.Drawing.Color.White;
            this.dialog_title_label.Location = new System.Drawing.Point(3, 11);
            this.dialog_title_label.Name = "dialog_title_label";
            this.dialog_title_label.Size = new System.Drawing.Size(102, 26);
            this.dialog_title_label.TabIndex = 0;
            this.dialog_title_label.Text = "Launcher";
            // 
            // subject_name_label
            // 
            this.subject_name_label.AutoSize = true;
            this.subject_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subject_name_label.Location = new System.Drawing.Point(57, 3);
            this.subject_name_label.Name = "subject_name_label";
            this.subject_name_label.Size = new System.Drawing.Size(136, 17);
            this.subject_name_label.TabIndex = 1;
            this.subject_name_label.Text = "No subject found.";
            // 
            // subject_path_label
            // 
            this.subject_path_label.AutoSize = true;
            this.subject_path_label.Location = new System.Drawing.Point(57, 20);
            this.subject_path_label.Name = "subject_path_label";
            this.subject_path_label.Size = new System.Drawing.Size(32, 13);
            this.subject_path_label.TabIndex = 2;
            this.subject_path_label.Text = "Path:";
            // 
            // subject_last_accessed_label
            // 
            this.subject_last_accessed_label.AutoSize = true;
            this.subject_last_accessed_label.Location = new System.Drawing.Point(57, 33);
            this.subject_last_accessed_label.Name = "subject_last_accessed_label";
            this.subject_last_accessed_label.Size = new System.Drawing.Size(79, 13);
            this.subject_last_accessed_label.TabIndex = 3;
            this.subject_last_accessed_label.Text = "Last accessed:";
            // 
            // action_name_label
            // 
            this.action_name_label.AutoSize = true;
            this.action_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.action_name_label.Location = new System.Drawing.Point(57, 3);
            this.action_name_label.Name = "action_name_label";
            this.action_name_label.Size = new System.Drawing.Size(133, 17);
            this.action_name_label.TabIndex = 2;
            this.action_name_label.Text = "Action to perform";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 260);
            this.Controls.Add(this.back_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Launcher";
            this.Opacity = 0.8;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.Launcher_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Launcher_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Launcher_KeyUp);
            this.back_panel.ResumeLayout(false);
            this.back_panel.PerformLayout();
            this.action_panel.ResumeLayout(false);
            this.action_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.action_thumbnail)).EndInit();
            this.subject_panel.ResumeLayout(false);
            this.subject_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subject_thumbnail)).EndInit();
            this.info_panel.ResumeLayout(false);
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            this.launcher_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel back_panel;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.Label dialog_title_label;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Label indexer_status_label;
        private System.Windows.Forms.Panel action_panel;
        private System.Windows.Forms.Label action_label;
        private System.Windows.Forms.Panel subject_panel;
        private System.Windows.Forms.PictureBox subject_thumbnail;
        private System.Windows.Forms.PictureBox action_thumbnail;
        private System.Windows.Forms.Label launchable_name_label;
        private System.Windows.Forms.ContextMenuStrip launcher_menu;
        private System.Windows.Forms.ToolStripMenuItem reindexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Label subject_name_label;
        private System.Windows.Forms.Label action_name_label;
        private System.Windows.Forms.Label subject_last_accessed_label;
        private System.Windows.Forms.Label subject_path_label;

    }
}