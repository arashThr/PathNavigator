using System;
using NUnit.Framework;

namespace AddressAutoComplete
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void RootedDirecotries()
		{
			string compeletAddress = Completer.CompeletAddress(@"C:\Users\Ara")[0];
			Assert.AreEqual(@"C:\Users\Arash\", compeletAddress);
		}

		[Test]
		public void StartFromInitialDirectory()
		{
			Completer.DefaultDirectory = @"C:\Users\";
			string compeletAddress = Completer.CompeletAddress(@"Ara")[0];
			Assert.AreEqual(@"Arash\", compeletAddress);
		}

		[Test]
		public void IllegalChars()
		{
			string[] compeletAddress = Completer.CompeletAddress("<>");
			Assert.IsNull(compeletAddress);
		}

		[Test]
		public void UnauthorizedAccessToJunctionFiles()
		{
			const string addr = @"C:\Documents and Settings\Pub";
			string[] compeletAddress = Completer.CompeletAddress(addr);
			Assert.Null(compeletAddress);
		}

		[Test]
		public void DirectoryNotFoundException()
		{
			const string addr = @"C;\";
			string compeletAddress = Completer.CompeletAddress(addr)[0];
			Assert.AreEqual(addr, compeletAddress);
		}

		[Test]
		public void RootDirectoryDefaultAndInputEmpty()
		{
			string tmp = Completer.DefaultDirectory;
			Completer.DefaultDirectory = "C:\\";
			string[] compeletAddress = Completer.CompeletAddress("");
			Assert.IsTrue(compeletAddress.Length > 1);
			Completer.DefaultDirectory = tmp;
		}

		[Test]
		public void ShowFoldersInDriveTest()
		{
			string[] compeletAddress = Completer.CompeletAddress("C:\\");
			Assert.IsNotNull(compeletAddress);
		}

		[Test]
		public void UnhandledArgumentExceptionInPathTest()
		{
			string[] compeletAddress = Completer.CompeletAddress("::");
			Assert.IsNull(compeletAddress);
		}

		[Test]
		public void DefaultDirectoryNotEndsWithSlashTest()
		{
			Completer.DefaultDirectory = @"C:\User";
			// ...
		}
	}
}