namespace WindowsFormsInterface
{
	partial class SettingsDialog
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
			this.button_submit = new System.Windows.Forms.Button();
			this.textBox_defaultDir = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_explorer = new System.Windows.Forms.TextBox();
			this.checkBox_startup = new System.Windows.Forms.CheckBox();
			this.checkBox_alt = new System.Windows.Forms.CheckBox();
			this.checkBox_ctrl = new System.Windows.Forms.CheckBox();
			this.checkBox_shift = new System.Windows.Forms.CheckBox();
			this.textBox_shortcut = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox_loadBg = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button_submit
			// 
			this.button_submit.Location = new System.Drawing.Point(194, 140);
			this.button_submit.Name = "button_submit";
			this.button_submit.Size = new System.Drawing.Size(75, 23);
			this.button_submit.TabIndex = 0;
			this.button_submit.Text = "Submit";
			this.button_submit.UseVisualStyleBackColor = true;
			this.button_submit.Click += new System.EventHandler(this.button_Submit_Click);
			// 
			// textBox_defaultDir
			// 
			this.textBox_defaultDir.Location = new System.Drawing.Point(12, 29);
			this.textBox_defaultDir.Name = "textBox_defaultDir";
			this.textBox_defaultDir.Size = new System.Drawing.Size(257, 20);
			this.textBox_defaultDir.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(130, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Default directory address :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Shortcut :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Explorer :";
			// 
			// textBox_explorer
			// 
			this.textBox_explorer.Location = new System.Drawing.Point(12, 68);
			this.textBox_explorer.Name = "textBox_explorer";
			this.textBox_explorer.Size = new System.Drawing.Size(257, 20);
			this.textBox_explorer.TabIndex = 4;
			// 
			// checkBox_startup
			// 
			this.checkBox_startup.AutoSize = true;
			this.checkBox_startup.Location = new System.Drawing.Point(12, 144);
			this.checkBox_startup.Name = "checkBox_startup";
			this.checkBox_startup.Size = new System.Drawing.Size(91, 17);
			this.checkBox_startup.TabIndex = 5;
			this.checkBox_startup.Text = "Set as startup";
			this.checkBox_startup.UseVisualStyleBackColor = true;
			// 
			// checkBox_alt
			// 
			this.checkBox_alt.AutoSize = true;
			this.checkBox_alt.Location = new System.Drawing.Point(12, 108);
			this.checkBox_alt.Name = "checkBox_alt";
			this.checkBox_alt.Size = new System.Drawing.Size(38, 17);
			this.checkBox_alt.TabIndex = 6;
			this.checkBox_alt.Text = "Alt";
			this.checkBox_alt.UseVisualStyleBackColor = true;
			// 
			// checkBox_ctrl
			// 
			this.checkBox_ctrl.AutoSize = true;
			this.checkBox_ctrl.Location = new System.Drawing.Point(56, 107);
			this.checkBox_ctrl.Name = "checkBox_ctrl";
			this.checkBox_ctrl.Size = new System.Drawing.Size(41, 17);
			this.checkBox_ctrl.TabIndex = 6;
			this.checkBox_ctrl.Text = "Ctrl";
			this.checkBox_ctrl.UseVisualStyleBackColor = true;
			// 
			// checkBox_shift
			// 
			this.checkBox_shift.AutoSize = true;
			this.checkBox_shift.Location = new System.Drawing.Point(103, 107);
			this.checkBox_shift.Name = "checkBox_shift";
			this.checkBox_shift.Size = new System.Drawing.Size(47, 17);
			this.checkBox_shift.TabIndex = 6;
			this.checkBox_shift.Text = "Shift";
			this.checkBox_shift.UseVisualStyleBackColor = true;
			// 
			// textBox_shortcut
			// 
			this.textBox_shortcut.Location = new System.Drawing.Point(176, 104);
			this.textBox_shortcut.Name = "textBox_shortcut";
			this.textBox_shortcut.Size = new System.Drawing.Size(20, 20);
			this.textBox_shortcut.TabIndex = 7;
			this.textBox_shortcut.Enter += new System.EventHandler(this.textBox_shortcut_Enter);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(157, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "F";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(156, 171);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 26);
			this.label5.TabIndex = 9;
			this.label5.Text = "To apply new settings,\r\nrestart required.";
			// 
			// checkBox_loadBg
			// 
			this.checkBox_loadBg.AutoSize = true;
			this.checkBox_loadBg.Location = new System.Drawing.Point(12, 167);
			this.checkBox_loadBg.Name = "checkBox_loadBg";
			this.checkBox_loadBg.Size = new System.Drawing.Size(82, 17);
			this.checkBox_loadBg.TabIndex = 10;
			this.checkBox_loadBg.Text = "Load Image";
			this.checkBox_loadBg.UseVisualStyleBackColor = true;
			// 
			// SettingsDialog
			// 
			this.AcceptButton = this.button_submit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(281, 206);
			this.Controls.Add(this.checkBox_loadBg);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox_shortcut);
			this.Controls.Add(this.checkBox_shift);
			this.Controls.Add(this.checkBox_ctrl);
			this.Controls.Add(this.checkBox_alt);
			this.Controls.Add(this.checkBox_startup);
			this.Controls.Add(this.textBox_explorer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_defaultDir);
			this.Controls.Add(this.button_submit);
			this.Name = "SettingsDialog";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_submit;
		private System.Windows.Forms.TextBox textBox_defaultDir;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_explorer;
		private System.Windows.Forms.CheckBox checkBox_startup;
		private System.Windows.Forms.CheckBox checkBox_alt;
		private System.Windows.Forms.CheckBox checkBox_ctrl;
		private System.Windows.Forms.CheckBox checkBox_shift;
		private System.Windows.Forms.TextBox textBox_shortcut;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox_loadBg;
	}
}