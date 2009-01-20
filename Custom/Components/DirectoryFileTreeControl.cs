using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Custom.ExtensionMethods;
using Custom.Exceptions;

namespace Custom.Components
{
	/// <summary>
	/// Pass this class a list of strings and it will parse them
	/// into a directory structure in a tree view
	/// <para>this is intended for use with a zip file (ie a virtual file structure).</para>
	/// <para>All directory seperator characters should be "/" not "\\"</para>
	/// </summary>
	public partial class DirectoryFileTreeControl : UserControl
	{
		protected List<FileDirectoryItem> mDirectoryList;

		public DirectoryFileTreeControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the List of strings that make up the directory list
		/// Does nothing if the list is null
		/// </summary>
		public List<string> DirectoryList
		{
			get
			{
				List<string> retVal = new List<string>();
				foreach (FileDirectoryItem fd in mDirectoryList)
				{
					retVal.Add(fd.FullPath);
				}
				return retVal;
			}
			set
			{
				if (value != null)
					mDirectoryList = value;
			}
		}

		// ToDo take name of current node and then find all its sub directories
		// Todo take the list of strings and extract a root directory list and populate the node with these directory nodes

		/// <summary>
		/// Populates the treeview control using root as the base.
		/// </summary>
		protected void PopulateTreeView()
		{
			if (mDirectoryList!=null)
			{
			TreeNode tn = new TreeNode();
			tn.Text="root";
			tn.Name = "";

			treeView1.Nodes.Add(AddChildNodes(tn,false));
			}
		}

		/// <summary>
		/// Function recursivley populates a tree node.
		/// When callign this final should always = false (it is set to true as a base case kicker)
		/// </summary>
		/// <param name="node">the treenode to use as a base for population</param>
		/// <param name="final">should be set to false generally. Set to true internally as a base case to end the recursion</param>
		/// <returns></returns>
		protected TreeNode AddChildNodes(TreeNode node,bool final)
		{
			//base case to end the recursion
			if (final)
				return node;

			return node;
		}

		protected List<string> GetDirectories(string root)
		{
			List<string> retVal = new List<string>();

			foreach (FileDirectoryItem fd in mDirectoryList)
			{
				if (fd.has

			}
			foreach (string s in mDirectoryList)
			{
				// test to see if string is a directory
				if (s.EndsWith("/"))
				{
					// test to see if part of the root path
					if (s.StartsWith(root))
					{
						// extract names of directories that are not sub directories
						// of any directories in the root path
						int rootCount = root.Count("/");
						int dirCount = s.Count("/");

						// a directory in root will only have 1 extra "/"
						if (rootCount==(dirCount-1))
						{
							// extract the directory name from the string
						}
							
					}
				}
			}

			return retVal;
		}

		/// <summary>
		/// represents a directory and filename as strings
		/// </summary>
		public class FileDirectoryItem
		{
			protected  string mRoot;
			protected string mName;

			protected bool mHasDirectory = false;
			protected bool mHasFileName = false;

			/// <summary>
			/// gets wether the object contains a Directory reference
			/// </summary>
			public bool HasDirectory
			{ get { return mHasDirectory; } }

			/// <summary>
			/// Gets wether the object contains a Filename reference
			/// </summary>
			public bool HasFileName
			{ get { return mHasFileName; } }

			/// <summary>
			/// gets or sets the root directory of the file
			/// </summary>
			public string Root
			{
				get { return mRoot; }
				set
				{
					if (value.Contains("."))
						throw new ArgumentInvalidPathFormatException("Tried to set directory with a filename: " + value);
					if (value.EndsWith("/"))
						value = value.Remove(value.Length - 1);
					mRoot = value;
					if (value == "")
					{
						mHasDirectory = false;
					}
					else
					{
						mHasDirectory = true;
					}
				}
			}

			/// <summary>
			/// gets or sets the file name of the reference. Must contain an extension (".")			
			/// </summary>
			public string Name
			{
				get { return mName; }
				set
				{
					if (!value.Contains("."))
						throw new ArgumentInvalidPathFormatException("Tried to set a filename that has no extension :" + value);

					if (value.Contains("/"))
					{
						int index = value.LastIndexOf("/");
						value = value.Substring(index + 1);
					}
					mName = value;
					if (value == "")
					{
						mHasFileName = false;
					}
					else
					{ mHasFileName = true; }
				}
			}

			/// <summary>
			/// gets or sets the full directory and file path.
			/// If just a filename with no directory then no leading "/"
			/// </summary>
			public string FullPath
			{
				get
				{
					if (mHasDirectory == true)
					{
						return Root + "/" + Name;
					}
					else
					{ return Name; }
				}
				set
				{
					if (value != "")
					{
						//establish index of last directory character
						int index = value.LastIndexOf("/");
						// use this index to separate string into directory and filename
						string fileName = value.Substring(index + 1);
						string directory = value.Substring(0, index);

						try
						{
							Name = fileName;
						}
						catch (ArgumentInvalidPathFormatException e)
						{
							throw new ArgumentInvalidPathFormatException("Filename part of FullPath invalid :" + fileName, e);
						}
						try
						{
							Root = directory;
						}
						catch (ArgumentInvalidPathFormatException e)
						{
							throw new ArgumentInvalidPathFormatException("Directory part of FullPath invalid :" + directory, e);
						}
					}
				}
			}
		}
				

		}
	}

	

