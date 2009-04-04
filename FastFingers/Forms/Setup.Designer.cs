namespace FastFingers.Forms
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.setup_pages_tab = new System.Windows.Forms.TabControl();
            this.general_page = new System.Windows.Forms.TabPage();
            this.general_settings_grid = new System.Windows.Forms.PropertyGrid();
            this.vdm_page = new System.Windows.Forms.TabPage();
            this.launcher_page = new System.Windows.Forms.TabPage();
            this.paster_page = new System.Windows.Forms.TabPage();
            this.user_switcher_page = new System.Windows.Forms.TabPage();
            this.cancel_button = new System.Windows.Forms.Button();
            this.apply_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dialog_title_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.setup_pages_tab.SuspendLayout();
            this.general_page.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // setup_pages_tab
            // 
            this.setup_pages_tab.Controls.Add(this.general_page);
            this.setup_pages_tab.Controls.Add(this.vdm_page);
            this.setup_pages_tab.Controls.Add(this.launcher_page);
            this.setup_pages_tab.Controls.Add(this.paster_page);
            this.setup_pages_tab.Controls.Add(this.user_switcher_page);
            this.setup_pages_tab.Location = new System.Drawing.Point(12, 62);
            this.setup_pages_tab.Name = "setup_pages_tab";
            this.setup_pages_tab.SelectedIndex = 0;
            this.setup_pages_tab.Size = new System.Drawing.Size(383, 399);
            this.setup_pages_tab.TabIndex = 4;
            // 
            // general_page
            // 
            this.general_page.Controls.Add(this.general_settings_grid);
            this.general_page.Location = new System.Drawing.Point(4, 24);
            this.general_page.Name = "general_page";
            this.general_page.Size = new System.Drawing.Size(375, 371);
            this.general_page.TabIndex = 4;
            this.general_page.Text = "General";
            this.general_page.UseVisualStyleBackColor = true;
            // 
            // general_settings_grid
            // 
            this.general_settings_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.general_settings_grid.HelpVisible = false;
            this.general_settings_grid.Location = new System.Drawing.Point(0, 0);
            this.general_settings_grid.Name = "general_settings_grid";
            this.general_settings_grid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.general_settings_grid.Size = new System.Drawing.Size(375, 371);
            this.general_settings_grid.TabIndex = 2;
            this.general_settings_grid.ToolbarVisible = false;
            this.general_settings_grid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.general_settings_grid_PropertyValueChanged);
            // 
            // vdm_page
            // 
            this.vdm_page.Location = new System.Drawing.Point(4, 24);
            this.vdm_page.Name = "vdm_page";
            this.vdm_page.Size = new System.Drawing.Size(375, 368);
            this.vdm_page.TabIndex = 0;
            this.vdm_page.Text = "Virtual Desktop Manager";
            this.vdm_page.UseVisualStyleBackColor = true;
            // 
            // launcher_page
            // 
            this.launcher_page.Location = new System.Drawing.Point(4, 24);
            this.launcher_page.Name = "launcher_page";
            this.launcher_page.Size = new System.Drawing.Size(375, 368);
            this.launcher_page.TabIndex = 1;
            this.launcher_page.Text = "Launcher";
            this.launcher_page.UseVisualStyleBackColor = true;
            // 
            // paster_page
            // 
            this.paster_page.Location = new System.Drawing.Point(4, 24);
            this.paster_page.Name = "paster_page";
            this.paster_page.Size = new System.Drawing.Size(375, 368);
            this.paster_page.TabIndex = 2;
            this.paster_page.Text = "Paster";
            this.paster_page.UseVisualStyleBackColor = true;
            // 
            // user_switcher_page
            // 
            this.user_switcher_page.Location = new System.Drawing.Point(4, 24);
            this.user_switcher_page.Name = "user_switcher_page";
            this.user_switcher_page.Size = new System.Drawing.Size(375, 368);
            this.user_switcher_page.TabIndex = 3;
            this.user_switcher_page.Text = "User Switcher";
            this.user_switcher_page.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(323, 9);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 27);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // apply_button
            // 
            this.apply_button.Enabled = false;
            this.apply_button.Location = new System.Drawing.Point(238, 9);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(75, 27);
            this.apply_button.TabIndex = 2;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
            // 
            // ok_button
            // 
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_button.Location = new System.Drawing.Point(157, 9);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 27);
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dialog_title_label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 55);
            this.panel1.TabIndex = 4;
            // 
            // dialog_title_label
            // 
            this.dialog_title_label.AutoSize = true;
            this.dialog_title_label.BackColor = System.Drawing.Color.Transparent;
            this.dialog_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog_title_label.ForeColor = System.Drawing.Color.White;
            this.dialog_title_label.Location = new System.Drawing.Point(6, 12);
            this.dialog_title_label.Name = "dialog_title_label";
            this.dialog_title_label.Size = new System.Drawing.Size(211, 26);
            this.dialog_title_label.TabIndex = 0;
            this.dialog_title_label.Text = "FastFingers Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ok_button);
            this.panel2.Controls.Add(this.apply_button);
            this.panel2.Controls.Add(this.cancel_button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(406, 43);
            this.panel2.TabIndex = 5;
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 512);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.setup_pages_tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setup";
            this.Text = "FastFingers Settings";
            this.setup_pages_tab.ResumeLayout(false);
            this.general_page.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl setup_pages_tab;
        private System.Windows.Forms.TabPage vdm_page;
        private System.Windows.Forms.TabPage launcher_page;
        private System.Windows.Forms.TabPage paster_page;
        private System.Windows.Forms.TabPage user_switcher_page;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dialog_title_label;
        private System.Windows.Forms.TabPage general_page;
        private System.Windows.Forms.PropertyGrid general_settings_grid;
        private System.Windows.Forms.Panel panel2;
    }
}

