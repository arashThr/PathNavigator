using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using AddressAutoComplete;
using System.Text;

namespace WindowsFormsInterface
{
	public partial class MainForm : Form
	{
		public static string Explorer { get; set; }
		public static string DefaultExplorer { get { return @"C:\Windows\explorer.exe"; } }
		public static AddressAutoComplete.ModifierKeys HotKeyModifiers = AddressAutoComplete.ModifierKeys.Alt;
		public static Keys HotKeyFKey = Keys.F2;
		public static string configFileName = @"config.txt";
		public static bool LoadBackgroundImage = false;

		KeyboardHook hook = new KeyboardHook();

		/// <summary>
		/// Shows whether a new character has been entered or it's just a control key
		/// </summary>
		private int _lastIndex = -1;

		public MainForm()
		{
			InitializeComponent();
			// register the event that is fired after the key press.
			hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
			// register the certain key combination as hot key.
			//hook.RegisterHotKey(AddressAutoComplete.ModifierKeys.Control | AddressAutoComplete.ModifierKeys.Alt, Keys.F12);
			if (File.Exists(configFileName))
				Initialize();
			hook.RegisterHotKey(HotKeyModifiers, HotKeyFKey);
		}

		private void Initialize()
		{
			string[] conf = File.ReadAllLines(configFileName);
			var builder = new StringBuilder();
			foreach (string line in conf)
			{
				if (line.StartsWith("#") || line == string.Empty)
					continue;
				string[] parts = line.Split('=');
				if(parts.Length != 2)
					throw new Exception("Configuration file has syntax error");

				string var = parts[0];
				string value = parts[1];

				if(var.StartsWith("Hotkey"))
				{
					string[] hotkies = parts[1].Split('|');
					if (hotkies.Any(s => s == "Alt"))
						HotKeyModifiers |= AddressAutoComplete.ModifierKeys.Alt;
					if (hotkies.Any(s => s == "Ctrl"))
						HotKeyModifiers |= AddressAutoComplete.ModifierKeys.Control;
					if (hotkies.Any(s => s == "Shift"))
						HotKeyModifiers |= AddressAutoComplete.ModifierKeys.Shift;
					string key = hotkies.Last();

					SetFKey(key);
					if(HotKeyModifiers.ToString() == "")
						throw new Exception("Configuration file has syntax error : Hotkey");
				}
				else if(var.StartsWith("InitDir"))
				{
					if(Directory.Exists(value))
						Completer.DefaultDirectory = value;
					else
						throw new Exception("Configuration file has syntax error : Dir");
				}
				else if(var.StartsWith("Explorer"))
				{
					if(File.Exists(value))
						Explorer = value;
					else
						throw new Exception("Configuration file has syntax error : Explorer");
				}
				else if (var.StartsWith("LoadBg"))
				{
					LoadBackgroundImage = value == "true";
					if (LoadBackgroundImage)
					{
						Stream bgImageStream = Assembly.GetExecutingAssembly()
							.GetManifestResourceStream("WindowsFormsInterface.gogh.starry-night.jpg");
						if (bgImageStream != null)
							BackgroundImage = new Bitmap(bgImageStream);
					}
				}
				else
					throw new Exception("Configuration file has syntax error");
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x312) // this is WM_HOTKEY
				Show();
			base.WndProc(ref m);
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Tab) return false;
			return base.ProcessDialogKey(keyData);
		}

		private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
		{
			int keyValue = e.KeyValue;
			Keys modifiers = e.Modifiers;

			string enteredText = textBoxAddress.Text;
			string selectedText = textBoxAddress.SelectedText;
			if(selectedText != string.Empty)
				enteredText = enteredText.Remove(enteredText.Length - selectedText.Length);

			if ((Char.IsLetter((char)keyValue) && (modifiers == Keys.None || modifiers == Keys.Shift)))
			{
				_lastIndex = -1;
				string[] compeletAddress = Completer.CompeletAddress(enteredText + (char)keyValue);
				if (compeletAddress != null && compeletAddress.Length == 1)
				{
					textBoxAddress.Text = compeletAddress.Single();
					textBoxAddress.Select(enteredText.Length + 1, textBoxAddress.Text.Length);
					e.SuppressKeyPress = true;
				}
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			string addr = textBoxAddress.Text;
			if (keyData == Keys.Enter)
			{
				OpenDirectory(addr);
				return true;
			}
			if (keyData == Keys.Escape)
			{
				MainForm_Deactivate(null, null);
				return true;
			}

			string enteredText = textBoxAddress.Text;
			string selectedText = textBoxAddress.SelectedText;
			if (selectedText != string.Empty)
				enteredText = enteredText.Remove(enteredText.Length - selectedText.Length);
			string[] compeletAddress = Completer.CompeletAddress(enteredText);

			if (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift))
			{
				if (compeletAddress != null)
				{
					if (compeletAddress.Length == 1)
					{
						textBoxAddress.Text = compeletAddress.Single();
						textBoxAddress.Select(textBoxAddress.Text.Length, 0);
					}
					else if (keyData == Keys.Tab)
					{
						_lastIndex = (_lastIndex + 1) % compeletAddress.Length;
						textBoxAddress.Text = compeletAddress[_lastIndex];
						textBoxAddress.Select(enteredText.Length, textBoxAddress.Text.Length);
						//e.SuppressKeyPress = true;
					}
					else if (keyData == (Keys.Tab | Keys.Shift))
					{
						_lastIndex = (_lastIndex - 1) % compeletAddress.Length;
						if (_lastIndex < 0)
							_lastIndex = compeletAddress.Length - 1;
						textBoxAddress.Text = compeletAddress[_lastIndex];
						textBoxAddress.Select(enteredText.Length, textBoxAddress.Text.Length);
					}
				}
				// Return true is in order to prevent beeping !
				return true;
			}
			if (keyData == Keys.Space && textBoxAddress.SelectedText != string.Empty)
			{
				textBoxAddress.Select(textBoxAddress.Text.Length, 0);
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private static void OpenDirectory(string addr)
		{
			if (Explorer == null)
				Explorer = DefaultExplorer;
			if (!Path.IsPathRooted(addr))
				addr = Path.Combine(Completer.DefaultDirectory, addr);
			if (Directory.Exists(addr))
				Process.Start(Explorer, addr);
		}

		private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
		{
			textBoxAddress.Text = string.Empty;
			Show();
			Activate();
		}

		private void MainForm_Deactivate(object sender, EventArgs e)
		{
			Hide();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sd = new SettingsDialog();
			DialogResult dialogResult = sd.ShowDialog();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var sd = new HelpForm();
			DialogResult dialogResult = sd.ShowDialog();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SetFKey(string key)
		{
			switch (key)
			{
				case "F1" :
					HotKeyFKey = Keys.F1;
					break;
				case "F2":
					HotKeyFKey = Keys.F2;
					break;
				case "F3":
					HotKeyFKey = Keys.F3;
					break;
				case "F4":
					HotKeyFKey = Keys.F4;
					break;
				case "F5":
					HotKeyFKey = Keys.F5;
					break;
				case "F6":
					HotKeyFKey = Keys.F6;
					break;
				case "F7":
					HotKeyFKey = Keys.F7;
					break;
				case "F8":
					HotKeyFKey = Keys.F8;
					break;
				case "F9":
					HotKeyFKey = Keys.F9;
					break;
				case "F10":
					HotKeyFKey = Keys.F10;
					break;
				case "F11":
					HotKeyFKey = Keys.F11;
					break;
				case "F12":
					HotKeyFKey = Keys.F12;
					break;
				default:
					throw new Exception("Configuration file has syntax error : HotKey, FKey");
			}
		}
	}
}
