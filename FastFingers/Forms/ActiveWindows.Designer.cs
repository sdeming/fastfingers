namespace FastFingers.Forms
{
    partial class ActiveWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveWindows));
            this.title_panel = new System.Windows.Forms.Panel();
            this.dialog_title_label = new System.Windows.Forms.Label();
            this.actions_panel = new System.Windows.Forms.Panel();
            this.action_buttons_justifier_panel = new System.Windows.Forms.Panel();
            this.refresh_visible_button = new System.Windows.Forms.Button();
            this.bring_in_button = new System.Windows.Forms.Button();
            this.refresh_all_button = new System.Windows.Forms.Button();
            this.toggle_button = new System.Windows.Forms.Button();
            this.windows_view = new System.Windows.Forms.ListView();
            this.handle_column = new System.Windows.Forms.ColumnHeader();
            this.pid_column = new System.Windows.Forms.ColumnHeader();
            this.title_column = new System.Windows.Forms.ColumnHeader();
            this.file_column = new System.Windows.Forms.ColumnHeader();
            this.visible_column = new System.Windows.Forms.ColumnHeader();
            this.dimensions_column = new System.Windows.Forms.ColumnHeader();
            this.z_order_column = new System.Windows.Forms.ColumnHeader();
            this.title_panel.SuspendLayout();
            this.actions_panel.SuspendLayout();
            this.action_buttons_justifier_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_panel
            // 
            this.title_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title_panel.BackgroundImage")));
            this.title_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.title_panel.Controls.Add(this.dialog_title_label);
            this.title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(817, 48);
            this.title_panel.TabIndex = 5;
            // 
            // dialog_title_label
            // 
            this.dialog_title_label.AutoSize = true;
            this.dialog_title_label.BackColor = System.Drawing.Color.Transparent;
            this.dialog_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialog_title_label.ForeColor = System.Drawing.Color.White;
            this.dialog_title_label.Location = new System.Drawing.Point(6, 10);
            this.dialog_title_label.Name = "dialog_title_label";
            this.dialog_title_label.Size = new System.Drawing.Size(167, 26);
            this.dialog_title_label.TabIndex = 0;
            this.dialog_title_label.Text = "Active Windows";
            // 
            // actions_panel
            // 
            this.actions_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.actions_panel.Controls.Add(this.action_buttons_justifier_panel);
            this.actions_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actions_panel.Location = new System.Drawing.Point(0, 333);
            this.actions_panel.Name = "actions_panel";
            this.actions_panel.Size = new System.Drawing.Size(817, 48);
            this.actions_panel.TabIndex = 6;
            // 
            // action_buttons_justifier_panel
            // 
            this.action_buttons_justifier_panel.Controls.Add(this.refresh_visible_button);
            this.action_buttons_justifier_panel.Controls.Add(this.bring_in_button);
            this.action_buttons_justifier_panel.Controls.Add(this.refresh_all_button);
            this.action_buttons_justifier_panel.Controls.Add(this.toggle_button);
            this.action_buttons_justifier_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.action_buttons_justifier_panel.Location = new System.Drawing.Point(0, 0);
            this.action_buttons_justifier_panel.Name = "action_buttons_justifier_panel";
            this.action_buttons_justifier_panel.Size = new System.Drawing.Size(813, 44);
            this.action_buttons_justifier_panel.TabIndex = 2;
            // 
            // refresh_visible_button
            // 
            this.refresh_visible_button.Location = new System.Drawing.Point(687, 11);
            this.refresh_visible_button.Name = "refresh_visible_button";
            this.refresh_visible_button.Size = new System.Drawing.Size(55, 23);
            this.refresh_visible_button.TabIndex = 3;
            this.refresh_visible_button.Text = "Visible";
            this.refresh_visible_button.UseVisualStyleBackColor = true;
            this.refresh_visible_button.Click += new System.EventHandler(this.refresh_visible_button_Click);
            // 
            // bring_in_button
            // 
            this.bring_in_button.Location = new System.Drawing.Point(10, 11);
            this.bring_in_button.Name = "bring_in_button";
            this.bring_in_button.Size = new System.Drawing.Size(94, 23);
            this.bring_in_button.TabIndex = 2;
            this.bring_in_button.Text = "Bring In-Screen";
            this.bring_in_button.UseVisualStyleBackColor = true;
            this.bring_in_button.Click += new System.EventHandler(this.bring_in_button_Click);
            // 
            // refresh_all_button
            // 
            this.refresh_all_button.Location = new System.Drawing.Point(748, 11);
            this.refresh_all_button.Name = "refresh_all_button";
            this.refresh_all_button.Size = new System.Drawing.Size(55, 23);
            this.refresh_all_button.TabIndex = 1;
            this.refresh_all_button.Text = "All";
            this.refresh_all_button.UseVisualStyleBackColor = true;
            this.refresh_all_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // toggle_button
            // 
            this.toggle_button.Location = new System.Drawing.Point(110, 11);
            this.toggle_button.Name = "toggle_button";
            this.toggle_button.Size = new System.Drawing.Size(75, 23);
            this.toggle_button.TabIndex = 1;
            this.toggle_button.Text = "Show/Hide";
            this.toggle_button.UseVisualStyleBackColor = true;
            this.toggle_button.Click += new System.EventHandler(this.toggle_button_Click);
            // 
            // windows_view
            // 
            this.windows_view.BackColor = System.Drawing.SystemColors.Window;
            this.windows_view.CheckBoxes = true;
            this.windows_view.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title_column,
            this.handle_column,
            this.pid_column,
            this.file_column,
            this.visible_column,
            this.dimensions_column,
            this.z_order_column});
            this.windows_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windows_view.FullRowSelect = true;
            this.windows_view.HideSelection = false;
            this.windows_view.Location = new System.Drawing.Point(0, 48);
            this.windows_view.MultiSelect = false;
            this.windows_view.Name = "windows_view";
            this.windows_view.Size = new System.Drawing.Size(817, 285);
            this.windows_view.TabIndex = 7;
            this.windows_view.UseCompatibleStateImageBehavior = false;
            this.windows_view.View = System.Windows.Forms.View.Details;
            // 
            // handle_column
            // 
            this.handle_column.Text = "Handle";
            this.handle_column.Width = 74;
            // 
            // pid_column
            // 
            this.pid_column.Text = "PID";
            // 
            // title_column
            // 
            this.title_column.Text = "Title";
            this.title_column.Width = 289;
            // 
            // file_column
            // 
            this.file_column.Text = "Filename";
            this.file_column.Width = 104;
            // 
            // visible_column
            // 
            this.visible_column.Text = "Visible";
            this.visible_column.Width = 46;
            // 
            // dimensions_column
            // 
            this.dimensions_column.Text = "Dimensions";
            this.dimensions_column.Width = 131;
            // 
            // z_order_column
            // 
            this.z_order_column.Text = "~Z-Order";
            // 
            // ActiveWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 381);
            this.ControlBox = false;
            this.Controls.Add(this.windows_view);
            this.Controls.Add(this.actions_panel);
            this.Controls.Add(this.title_panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActiveWindows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActiveWindows";
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            this.actions_panel.ResumeLayout(false);
            this.action_buttons_justifier_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.Label dialog_title_label;
        private System.Windows.Forms.Panel actions_panel;
        private System.Windows.Forms.Button toggle_button;
        private System.Windows.Forms.Panel action_buttons_justifier_panel;
        private System.Windows.Forms.Button refresh_all_button;
        private System.Windows.Forms.ListView windows_view;
        private System.Windows.Forms.ColumnHeader handle_column;
        private System.Windows.Forms.ColumnHeader title_column;
        private System.Windows.Forms.ColumnHeader visible_column;
        private System.Windows.Forms.ColumnHeader dimensions_column;
        private System.Windows.Forms.Button bring_in_button;
        private System.Windows.Forms.ColumnHeader z_order_column;
        private System.Windows.Forms.Button refresh_visible_button;
        private System.Windows.Forms.ColumnHeader pid_column;
        private System.Windows.Forms.ColumnHeader file_column;
    }
}