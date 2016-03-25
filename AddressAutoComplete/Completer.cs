using System;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressAutoComplete
{
	public static class Completer
	{
		private static string _defaultDirectory;
		public static string DefaultDirectory
		{
			get {
				return _defaultDirectory ??
				       (_defaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\");
			}
			set
			{
				if (!value.EndsWith("\\"))
					value += "\\";
				_defaultDirectory = value;
			}
		}

		public static string[] CompeletAddress(string addr)
		{
			if (addr.Any(Path.GetInvalidPathChars().Contains))
				return null;

			string expectedDir = Path.GetFileName(addr);
			string path = null;

			try
			{
				if (Path.GetPathRoot(addr) == addr)
					path = addr;
				else
					path = Path.IsPathRooted(addr)
						? Path.GetDirectoryName(addr)
						: Path.GetDirectoryName(Path.Combine(DefaultDirectory, addr));
			}
			catch (ArgumentException)
			{
				return null;
			}

			if (DefaultDirectory == Path.GetPathRoot(DefaultDirectory))
				path = DefaultDirectory;

			if (path == null)
				return null;

			if (!Directory.Exists(path))
				return new[] {addr};

			var builder = new StringBuilder();
			try
			{
				string[] directories = Directory.GetDirectories(path);
				foreach (var directory in directories)
				{
					var dirName = Path.GetFileName(directory);
					// $RecycleBin
					if (dirName == null || dirName.StartsWith("$"))
						continue;
					if (expectedDir != null && dirName.ToLower().StartsWith(expectedDir.ToLower()))
					{
						if (Path.IsPathRooted(addr))
							builder.Append(directory + "\\#");
						else
							builder.Append(directory.Replace(DefaultDirectory, "") + "\\#");
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				return null;
			}

			if (builder.ToString() != string.Empty)
				return builder.ToString().Split('#').Where(s => s!=string.Empty).ToArray();
			return null;
		}
	}
}