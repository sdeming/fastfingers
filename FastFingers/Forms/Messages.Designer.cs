namespace FastFingers.Forms
{
    partial class Messages
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
            this.panel_border = new System.Windows.Forms.Panel();
            this.label_message = new System.Windows.Forms.Label();
            this.fader_timer = new System.Windows.Forms.Timer(this.components);
            this.panel_border.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_border
            // 
            this.panel_border.BackColor = System.Drawing.Color.White;
            this.panel_border.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_border.Controls.Add(this.label_message);
            this.panel_border.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_border.Location = new System.Drawing.Point(0, 0);
            this.panel_border.Name = "panel_border";
            this.panel_border.Size = new System.Drawing.Size(320, 64);
            this.panel_border.TabIndex = 0;
            // 
            // label_message
            // 
            this.label_message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_message.Location = new System.Drawing.Point(11, 8);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(296, 46);
            this.label_message.TabIndex = 0;
            this.label_message.Text = "No messages";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fader_timer
            // 
            this.fader_timer.Tick += new System.EventHandler(this.fader_timer_Tick);
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 64);
            this.ControlBox = false;
            this.Controls.Add(this.panel_border);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Messages";
            this.Opacity = 0.99;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Messages";
            this.panel_border.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_border;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Timer fader_timer;
    }
}