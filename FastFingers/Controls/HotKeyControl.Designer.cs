namespace FastFingers.Controls
{
  partial class HotKeyControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.windows_check = new System.Windows.Forms.CheckBox();
      this.alt_check = new System.Windows.Forms.CheckBox();
      this.shift_check = new System.Windows.Forms.CheckBox();
      this.control_check = new System.Windows.Forms.CheckBox();
      this.key_text = new System.Windows.Forms.TextBox();
      this.okay_button = new System.Windows.Forms.Button();
      this.action_key_label = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // windows_check
      // 
      this.windows_check.AutoSize = true;
      this.windows_check.Location = new System.Drawing.Point(65, 77);
      this.windows_check.Name = "windows_check";
      this.windows_check.Size = new System.Drawing.Size(70, 17);
      this.windows_check.TabIndex = 3;
      this.windows_check.TabStop = false;
      this.windows_check.Text = "Windows";
      this.windows_check.UseVisualStyleBackColor = true;
      this.windows_check.CheckedChanged += new System.EventHandler(this.windows_check_CheckedChanged);
      // 
      // alt_check
      // 
      this.alt_check.AutoSize = true;
      this.alt_check.Location = new System.Drawing.Point(12, 77);
      this.alt_check.Name = "alt_check";
      this.alt_check.Size = new System.Drawing.Size(38, 17);
      this.alt_check.TabIndex = 2;
      this.alt_check.TabStop = false;
      this.alt_check.Text = "Alt";
      this.alt_check.UseVisualStyleBackColor = true;
      this.alt_check.CheckedChanged += new System.EventHandler(this.alt_check_CheckedChanged);
      // 
      // shift_check
      // 
      this.shift_check.AutoSize = true;
      this.shift_check.Location = new System.Drawing.Point(12, 54);
      this.shift_check.Name = "shift_check";
      this.shift_check.Size = new System.Drawing.Size(47, 17);
      this.shift_check.TabIndex = 1;
      this.shift_check.TabStop = false;
      this.shift_check.Text = "Shift";
      this.shift_check.UseVisualStyleBackColor = true;
      this.shift_check.CheckedChanged += new System.EventHandler(this.shift_check_CheckedChanged);
      // 
      // control_check
      // 
      this.control_check.AutoSize = true;
      this.control_check.Location = new System.Drawing.Point(65, 54);
      this.control_check.Name = "control_check";
      this.control_check.Size = new System.Drawing.Size(59, 17);
      this.control_check.TabIndex = 0;
      this.control_check.TabStop = false;
      this.control_check.Text = "Control";
      this.control_check.UseVisualStyleBackColor = true;
      this.control_check.CheckStateChanged += new System.EventHandler(this.control_check_CheckStateChanged);
      // 
      // key_text
      // 
      this.key_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.key_text.Location = new System.Drawing.Point(9, 22);
      this.key_text.Name = "key_text";
      this.key_text.ReadOnly = true;
      this.key_text.Size = new System.Drawing.Size(251, 26);
      this.key_text.TabIndex = 0;
      this.key_text.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.key_text_PreviewKeyDown);
      // 
      // okay_button
      // 
      this.okay_button.Location = new System.Drawing.Point(185, 71);
      this.okay_button.Name = "okay_button";
      this.okay_button.Size = new System.Drawing.Size(75, 23);
      this.okay_button.TabIndex = 4;
      this.okay_button.Text = "OK";
      this.okay_button.UseVisualStyleBackColor = true;
      this.okay_button.Click += new System.EventHandler(this.okay_button_Click);
      // 
      // action_key_label
      // 
      this.action_key_label.AutoSize = true;
      this.action_key_label.Location = new System.Drawing.Point(6, 6);
      this.action_key_label.Name = "action_key_label";
      this.action_key_label.Size = new System.Drawing.Size(65, 13);
      this.action_key_label.TabIndex = 5;
      this.action_key_label.Text = "Press a key:";
      // 
      // HotKeyControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.action_key_label);
      this.Controls.Add(this.windows_check);
      this.Controls.Add(this.key_text);
      this.Controls.Add(this.shift_check);
      this.Controls.Add(this.alt_check);
      this.Controls.Add(this.okay_button);
      this.Controls.Add(this.control_check);
      this.Name = "HotKeyControl";
      this.Size = new System.Drawing.Size(269, 105);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox windows_check;
    private System.Windows.Forms.CheckBox alt_check;
    private System.Windows.Forms.CheckBox shift_check;
    private System.Windows.Forms.CheckBox control_check;
    private System.Windows.Forms.TextBox key_text;
    private System.Windows.Forms.Button okay_button;
    private System.Windows.Forms.Label action_key_label;
  }
}
