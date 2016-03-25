using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AddressAutoComplete;
using System.Text;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace WindowsFormsInterface
{
	public partial class SettingsDialog : Form
	{
		public SettingsDialog()
		{
			InitializeComponent();
		}

		private void button_Submit_Click(object sender, EventArgs e)
		{
			string addr = textBox_defaultDir.Text;
			var builder = new StringBuilder();
			if (Directory.Exists(addr))
			{
				Completer.DefaultDirectory = addr;
				builder.Append("InitDir=" + addr + Environment.NewLine);
			}
			if (File.Exists(textBox_explorer.Text))
			{
				MainForm.Explorer = textBox_explorer.Text;
				builder.Append("Explorer=" + textBox_explorer.Text + Environment.NewLine);
			}

//			if (checkBox_startup.Checked)
//				InstallOnStartUp();
//			if (!checkBox_startup.Checked)
//				UninstallOnStartUp();

			if (checkBox_loadBg.Checked)
			{
				builder.Append("LoadBg=true" + Environment.NewLine);
				MainForm.LoadBackgroundImage = true;
			}
			else
			{
				builder.Append("LoadBg=false" + Environment.NewLine);
				MainForm.LoadBackgroundImage = false;
			}

			builder.Append("Hotkey=");
			if (checkBox_alt.Checked)
				builder.Append("Alt|");
			if (checkBox_ctrl.Checked)
				builder.Append("Ctrl|");
			if (checkBox_shift.Checked)
				builder.Append("Shift|");
			int fNum;
			if (textBox_shortcut.Text != string.Empty && textBox_shortcut.Text.Length < 3 && int.TryParse(textBox_shortcut.Text, out fNum))
			{
				builder.Append("F" + fNum);
				File.WriteAllText(MainForm.configFileName, builder.ToString());
				DialogResult = DialogResult.OK;
			}
			else
				DialogResult = DialogResult.Ignore;
		}

		private void SettingsDialog_Load(object sender, EventArgs e)
		{
			textBox_defaultDir.Text = Completer.DefaultDirectory;
			textBox_explorer.Text = MainForm.Explorer ?? MainForm.DefaultExplorer;
			textBox_shortcut.Text = "2";
			checkBox_startup.Enabled = false;
			checkBox_loadBg.Checked = MainForm.LoadBackgroundImage;

			if ((MainForm.HotKeyModifiers & AddressAutoComplete.ModifierKeys.Alt) != 0)
				checkBox_alt.Checked = true;
			if ((MainForm.HotKeyModifiers & AddressAutoComplete.ModifierKeys.Control) != 0)
				checkBox_ctrl.Checked = true;
			if ((MainForm.HotKeyModifiers & AddressAutoComplete.ModifierKeys.Shift) != 0)
				checkBox_shift.Checked = true;
		}

		private void InstallOnStartUp()
		{
			//Microsoft.Win32.RegistryKey key =
			//	Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			//Assembly curAssembly = Assembly.GetExecutingAssembly();
			//if (key != null) key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
			try
			{
				string[] files = Directory.GetFiles(".");
				string linkUrl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "PathNavig.lnk");
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string shortcutLocation = linkUrl;//executingAssembly.Location;
				var shell = new WshShell();
				var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

				shortcut.Description = "My shortcut description";   // The description of the shortcut
				shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
				shortcut.TargetPath = executingAssembly.Location;//linkUrl;                 // The path of the file that will launch when the shortcut is run
				shortcut.Save(); 

//				File.WriteAllText(linkUrl, writer.ToString());
			}
			catch
			{ }
		}

		private void UninstallOnStartUp()
		{
			//Microsoft.Win32.RegistryKey key =
			//	Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			//Assembly curAssembly = Assembly.GetExecutingAssembly();
			//if (key != null && key.GetValue(curAssembly.GetName().ToString()) != null)
			//	key.DeleteValue(curAssembly.GetName().Name);
			try
			{
				string linkUrl = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup),
					"PathNavig.lnk");
				File.Delete(linkUrl);
			}
			catch
			{ }
		}

		private void textBox_shortcut_Enter(object sender, EventArgs e)
		{
			textBox_shortcut.Text = string.Empty;
		}
	}
}
