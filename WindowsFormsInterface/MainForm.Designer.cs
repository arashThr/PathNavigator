namespace WindowsFormsInterface
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.contextMenuStrip_mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon_pathIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.contextMenuStrip_mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.BackColor = System.Drawing.SystemColors.Menu;
			this.textBoxAddress.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxAddress.Location = new System.Drawing.Point(13, 17);
			this.textBoxAddress.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(468, 26);
			this.textBoxAddress.TabIndex = 0;
			this.textBoxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAddress_KeyDown);
			// 
			// contextMenuStrip_mainMenu
			// 
			this.contextMenuStrip_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.contextMenuStrip_mainMenu.Name = "contextMenuStrip_mainMenu";
			this.contextMenuStrip_mainMenu.Size = new System.Drawing.Size(117, 70);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// notifyIcon_pathIcon
			// 
			this.notifyIcon_pathIcon.ContextMenuStrip = this.contextMenuStrip_mainMenu;
			this.notifyIcon_pathIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_pathIcon.Icon")));
			this.notifyIcon_pathIcon.Text = "Panvig";
			this.notifyIcon_pathIcon.Visible = true;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.SteelBlue;
			this.label1.Location = new System.Drawing.Point(-3, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(497, 10);
			this.label1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.SteelBlue;
			this.label2.Location = new System.Drawing.Point(-3, -6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(497, 10);
			this.label2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.SteelBlue;
			this.label3.Location = new System.Drawing.Point(490, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(10, 60);
			this.label3.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.SteelBlue;
			this.label4.Location = new System.Drawing.Point(-6, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 60);
			this.label4.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(494, 58);
			this.ContextMenuStrip = this.contextMenuStrip_mainMenu;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxAddress);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Crimson;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Opacity = 0.9D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Path Navigator";
			this.TopMost = true;
			this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenuStrip_mainMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_mainMenu;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon_pathIcon;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}