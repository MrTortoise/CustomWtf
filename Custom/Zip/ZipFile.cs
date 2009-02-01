using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Custom.Interfaces;
using Custom.ExtensionMethods;
using Custom.Exceptions;

using Ionic.Utils.Zip;

namespace Custom.Zip
{
	/// <summary>
	/// Provides zip functionality geared around use in the game
	/// providing tree structures representing zip file contents
	/// all file paths are \ (or / as a special char)
	/// </summary>
	public class ZipFile : IContainsResource 
	{	
		protected Ionic.Utils.Zip.ZipFile mZipFile;
		protected List<ZipItem> mZipItems;

		protected string mFileName;
		/// <summary>
		/// Gets / Sets the filename of the ZipFile
		/// </summary>
		/// <seealso cref="Custom.Zip.ZipFile"/>
		public string FileName
		{
			get { return mFileName; }
			set {
				try
				{
					ValidateFilePath(value);
				}
				catch (ArgumentInvalidPathFormatException e)
				{
					throw new ArgumentInvalidPathFormatException("Tried to set FileName, but validation error:\n" + e.Message, e);
				}

				mFileName = value; }
		}
		/// <summary>
		/// Creates an empty zip file at the specified location with the specified name
		/// </summary>
		/// <param name="fullPath">
		/// The name and path of the zip file to be created
		/// Can be any extension
		/// </param>
		public void CreateFile(string fullPath)
		{			
			try
			{
				ValidateFilePath(fullPath);
			}
			catch (ArgumentInvalidPathFormatException e)
			{
				throw e;
			}

			try
			{
				mZipFile = new Ionic.Utils.Zip.ZipFile(fullPath);
			}
			catch (Exception e)
			{
				throw new Exception("Failed to create new zip file", e);
			}			
			mZipFile.Save();			
		}
		
		/// <summary>
		/// Returns a byte stream representing the specified zip file
		/// </summary>
		/// <param name="theFileName">the full path + name of the zip file to be streamed</param>
		/// <returns>a byte strean representing the zip file</returns>
		public Stream GetFile(string theFileName)
		{
			if (mZipFile == null)
				return null;

			Stream retVal = null;
			foreach (ZipEntry z in mZipFile)
			{
				if (z.FileName == theFileName)
				{
					z.Extract(retVal);
					return retVal;
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the entire contents of a zip file as a list of string
		/// </summary>
		/// <returns></returns>
		public List<string> GetAllContents()
		{
			List<string> retVal = new List<string>();
			foreach (ZipEntry ze in mZipFile)
			{
				retVal.Add(ze.FileName);
			}
			retVal.Sort();
			return retVal;
		}

		/// <summary>
		/// Given a directory to start from this returns all sub directories
		/// and shows their full path ... it shouldn't matter if / or \ is used
		/// </summary>
		/// <param name="root">the path of the directory to start from</param>
		/// <returns>List of strings representing the names of the sub directories</returns>
		public List<string> GetDirectoryListFullPathIncSub(string root)
		{
			try
			{
				ValidateZipDirectoryPath(root);
			}
			catch (ArgumentInvalidPathFormatException e)
			{
				throw new ArgumentInvalidPathFormatException("Tried to Get Directory List(inc subs) with Full Path Name using : " + root + "\n But : \n" + e.Message, e.Path, e);
			}
			List<string> s = new List<string>();
			// if root = empty then we want the root of the zip file
			if (root == "")
			{
				if (mZipFile != null)
				{
					foreach (ZipEntry z in mZipFile)
					{
						if (z.IsDirectory)
						{
							s.Add(z.FileName);
						}
					}
				}
				else
					return null;
			}
			else
			{
				if (mZipFile != null)
				{
					// check that root ends in a \ and then find only 
					// diretories beginnign with this		
					foreach (ZipEntry z in mZipFile)
					{
						if (z.IsDirectory)
						{
							if (z.FileName.StartsWith(root))
							{
								s.Add(z.FileName);
							}
						}
					}
				}
				else
					return null;
			}
			return s;			
		}

		/// <summary>
		/// Given a directory path this function returns the names of the sub directories
		/// Does not return any sub directories of the sub directories however
		/// </summary>
		/// <param name="root">the path of the directory to start from</param>
		/// <returns>A list of strings with full path names of the directories in the given directory</returns>
		public List<string> GetDirectoryListFullPath(string root)
		{
			try
			{
				ValidateZipDirectoryPath(root);
			}
			catch (ArgumentInvalidPathFormatException e)
			{
				throw new ArgumentInvalidPathFormatException("Tried to Get Directory List with Full Path Name using : " + root + "\n But : \n" + e.Message, e.Path, e);
			}
			if (mZipFile == null)
				return null;

			List<string> s = new List<string>();

			if (root == "")
			{
				foreach (ZipEntry z in mZipFile)
				{
					if (z.IsDirectory)
					{
						// we only want to return the directories that are root
						if (z.FileName.Count("/") == 1)
						{
							s.Add(z.FileName);
						}
					}
				}
			}
			else
			{
				// the directories in the zip file do not start with / therefor remove it if it exists
				if (root.StartsWith("/"))
				{ root = root.Remove(0, 1); }

				foreach (ZipEntry z in mZipFile)
				{
					if (z.IsDirectory)
					{
						// only want directories from specified root
						if (z.FileName.StartsWith(root))
						{
							
							// if the root path has no / then add it
							if (!root.EndsWith("/"))
								root = root + "/";
							// the directories that we want end in / so need to add 1 onto
							// the number of directories in the root
							int noDeep = root.Count("/");
							if (z.FileName.Count("/") == (root.Count("/") + 1))
							{
								s.Add(z.FileName);
							}
						}
					}
				}
			}
			return s;			
		}
		
		/// <summary>
		/// given a directory path as a root relative to the zip file root
		/// this will return a list of the parent directory names int he current directory
		/// It will not include any sub directories in its output
		/// ONLY returns the names of the directories and not their absolute paths relative to the zip root
		/// </summary>
		/// <param name="root">the path of the directory for which to return the directory names</param>
		/// <returns>List of directory names with no path</returns>
		public List<string> GetDirectoryList(string root)
		{
			List<string> sl;
			try
			{
				sl = GetDirectoryListFullPath(root);
			}
			catch (ArgumentInvalidPathFormatException e)
			{
				throw new ArgumentInvalidPathFormatException("Tried to Construct the Directory List Full Path for :" + root + "\n in order to process, But:\n" + e.Message, root, e);
			}
			List<string> target = new List<string>();
			string temp;
			int position = 0;
			
			if (sl == null)
				return null;

			foreach (string s in sl)
			{

				if (s.EndsWith("/"))
				{
					temp = s.Remove(s.Length - 1);
					// last index returns -1 if string not found
					position = temp.LastIndexOf("/");
					target.Add(temp.Substring(position + 1));
				}
			}
			return target;
		}
		
		/// <summary>
		/// returns the list of files including their path in the given directory
		/// </summary>
		/// <param name="root">the path of the directory relative to the root of the Zip file</param>
		/// <returns>List of strings each representing a file in the specified directory in the Zip file</returns>
		public List<string> GetFileListIncSubs(string root)
		{
			List<string> retVal = new List<string>();
			ValidateZipDirectoryPath(root);
			if (root.StartsWith("/"))
			{ root = root.Remove(0, 1); }

			//if the zip file has been set up then
			if (mZipFile != null)
			{
				// do work on the files (file = ! directory)
				foreach (ZipEntry ze in mZipFile)
				{
					if (!ze.IsDirectory)
					{
						if (ze.FileName.StartsWith(root))
						{
							retVal.Add(ze.FileName);
						}						
					}
				}
			}
			return retVal;
		}

		/// <summary>
		/// Gets the list of files Names in a given directory
		/// does not do subfoulders and does not include directory path
		/// </summary>
		/// <param name="root">the directory path from the zip root</param>
		/// <returns>a list<string> representing a list of file names</string></returns>
		public List<string> GetFileNameList(string root)
		{
			if (root.StartsWith("/"))
				root=root.Remove(0,1);

			List<string> retVal = new List<string>();
			List<string> intermed = GetFileListIncSubs(root);

			// strip off the trailing slash
			if (root.EndsWith("/"))
			{
				root = root.Remove(root.Length - 1);
			}		

			foreach (string s in intermed)
			{
				// strip out the root directory info
				int c = root.Length;
				string temp = s.Substring(c + 1);
				// if still contains some directory info then is a sub directory
				// so ignore - otherwise add it to the return list
				if (!temp.Contains("/"))
				{
					retVal.Add(temp);
				}
			}
			return retVal;
		}


		/// <summary>
		/// This validates a file path for a file inside the Zip file
		/// <para>Cannot Be Empty string, Must have a directory reference, must contain extension, filename must be non zero length and cannot contain a drive reference</para>
		/// </summary>
		/// <param name="fullPath"></param>
		/// <exception cref="Custom.Zip.ArgumentInvalidPathFormatException">
		/// Thrown when format of the input string is invalid in some way</exception>
		public void ValidateZipFilePath(string fullPath)
		{
			//empty string test
			if (fullPath == "")
				throw new ArgumentInvalidPathFormatException("Cannot have a zip file with an empty name: " + fullPath, fullPath);

			//no directory test
			if (!fullPath.Contains("/"))
			{
				throw new ArgumentInvalidPathFormatException("Cannot have a zip file with no directory reference: " + fullPath, fullPath);
			}

			//Test to ensure no drive reference
			if (fullPath.Contains(":"))
			{
				throw new ArgumentInvalidPathFormatException("Zip file path should not contain a drive reference: " + fullPath,fullPath);
			}

			//no extension test
			if (!fullPath.Contains("."))
			{
				throw new ArgumentInvalidPathFormatException("Cannot have zip file with no extension: " + fullPath, fullPath);
			}
			//no filename test
			int dirIndex = fullPath.LastIndexOf("/");
			int extIndex = fullPath.LastIndexOf(".");

			if (extIndex - dirIndex == 1)
			{
				throw new ArgumentInvalidPathFormatException("Filename has 0 characters in it");
			}


		}

		/// <summary>
		/// This function validates a path that references an actual file on the hard disk
		/// It is not intended for use on files inside the Zip file
		/// </summary>
		/// <param name="fullPath"></param>
		/// <returns></returns>
		/// <exception cref="Custom.Zip.ArgumentInvalidPathFormatException">
		/// Thrown when format of the input string is invalid in some way</exception>
		public void ValidateFilePath(string fullPath)
		{
			
			//empty string test
			if (fullPath == "")
				throw new ArgumentInvalidPathFormatException("Cannot have a zip file with an empty name: " + fullPath, fullPath);
			//no directory test
			if (!fullPath.Contains("\\"))
			{
				throw new ArgumentInvalidPathFormatException("Cannot have a zip file with no directory reference: " + fullPath, fullPath);
			}
			//no drive test
			if (!fullPath.Contains(":"))
			{
				throw new ArgumentInvalidPathFormatException("Cannot have Zip file with no Drive Reference: " + fullPath, fullPath);
			}
			// drive letter marker test
			if (fullPath.LastIndexOf(":") != 1)
			{
				throw new ArgumentInvalidPathFormatException("Drive marker is not in correct position: " + fullPath, fullPath);
			}

			//no extension test
			if (!fullPath.Contains("."))
			{
				throw new ArgumentInvalidPathFormatException("Cannot have zip file with no extension: " + fullPath, fullPath);
			}
			//no filename test
			int dirIndex = fullPath.LastIndexOf("\\");
			int extIndex = fullPath.LastIndexOf(".");

			if (extIndex - dirIndex == 1)
			{
				throw new ArgumentInvalidPathFormatException("Filename has 0 characters in it");
			}			
		}

		/// <summary>
		/// Validates a directory path withing a Zip file
		/// This means that there are no references to the drive
		/// can be an empty string to refer to root
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="Custom.Zip.ArgumentInvalidPathFormatException">
		/// Thrown when format of the input string is invalid in some way</exception>
		public void ValidateZipDirectoryPath(string path)
		{
			// Test for a drive marker
			if (path.Contains(":"))
			{ throw new ArgumentInvalidPathFormatException("The Zip Directory path contains a drive reference"); }

			// Test for a file extension
			if (path.Contains("."))
			{ throw new ArgumentInvalidPathFormatException("The Zip Directory contains an extension marker character"); }

			//char[] temp = "/".ToCharArray(0, 1);
			for (int i = 0; i < path.Length; i++)
			{
				if (!char.IsLetter(path[i]) && !char.IsNumber(path[i]))
				{
					if (path.Substring(i,1)!="/")
						throw new ArgumentInvalidPathFormatException("The path contains invalid characters", path.Substring(i, 1));
				}
			}
		}

		#region IContainsResource Members

		protected bool mIsOpen = false;
		/// <summary>
		/// Gets wether or not the Zip file has been opened
		/// </summary>
		public bool IsOpen
		{
			get { return mIsOpen ; }
		}

		/// <summary>
		/// Opens the Zip file
		/// </summary>
		/// <exception cref="Custom.Zip.ZipFileOpenException">Thrown when the group files fails to open</exception>
		public void Open()
		{
			if (mIsOpen == true)
			{
				Close();
			}
			try
			{
				mZipFile = new Ionic.Utils.Zip.ZipFile(mFileName);
			}
			catch (ZipException e)
			{
				throw new ZipFileOpenException(mFileName + " :Zip File Failed to Open", e);
			}
			
			mIsOpen = true;
		}

		/// <summary>
		/// This closes the zip file and frees up the resources without disposing of the object
		/// </summary>
		public void Close()
		{
			if (mIsOpen)
			{
				mZipFile.Dispose();
				mZipFile = null;
				mIsOpen = false;
			}
		}	

		#endregion
	}
}
