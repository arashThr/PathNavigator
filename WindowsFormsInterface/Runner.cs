using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsInterface
{
	public static class Runner
	{
		[STAThread]
		public static void Main(string[] args)
		{
			// TODO_done : Support shift-tab
			// TODO_done : Save settings
			// TODO_done : Run at start up
			// TODO_done : Tab completion when there's only Drive name
			// TODO : Show previous opend file address, all of it selected
			// TODO : Don't popup after execution, wait for call
			// TODO : History
			// TODO : Run executable files
			if (args.Length > 0 && File.Exists(args[0]))
				MainForm.Explorer = args[0];
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}