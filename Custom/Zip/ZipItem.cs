using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Custom.ExtensionMethods;
using Custom.IO;
using Custom.Exceptions;

namespace Custom.Zip
{
	public class ZipItem
	{
		protected string mPath; // must ensure that it terminates in '/'
		protected string mFileName; // cannot contain '/' or '.'
		protected string mExtension; // cannot contain '.'		
		

		/// <summary>
		/// Gets or sets the directory
		/// Will ignore the filename part 
		/// use input string to change the directory reference
		/// </summary>
		public string Directory
		{
			get { return mPath; }
			set
			{
				
				// if input is empty string or null then set to ""
				// otherwise process it
				if ((value != null) && (value != ""))
				{
					// true if many directories or if 1 directory with a '/' on end
					if (value.Contains("/"))
					{
						int cutoff = value.LastIndexOf("/");
						// if = then / is the last char
						if (cutoff == value.Length - 1)
						{
							mPath = value;
						}
						else
						{
							// test for extension
							// if true then filename else directory name
							if (value.Contains("."))
							{
								//must contain a filename also
								mPath = value.Substring(0, cutoff + 1);
							}
							else
							{
								// we know contains a '/' but this is not last char
								// we also know no '.' therefor last name is a directory
								mPath = value + "/";
							}
						}
					}
					else
					{
						// if no / thne assume the whole string is a directory name
						// add '/' so that everyting is consistent
						mPath = value + "/";
					}
				}
				else
				{
					mPath = "";
				}
			}
		}

		/// <summary>
		/// Gets / Sets the filename
		/// Saves anything after . as the extension
		/// If there are any '/' then ignores everything before
		/// Area inbetween becomes the filename nd are saved
		/// </summary>
		public string FileName
		{
			get { return mFileName; }
			set
			{				
				// if value is null or empty string then do nothing
				if ((value != "") && (value != null))
				{
					int dirIndex = 0;				//represents the start index
					int extIndex = value.Length - 1;//represents the end index
					// if contains a . then treat the last one as the extension
					// save the value and then use its index to extract the filename
					if (value.Contains("."))
					{
						extIndex = value.LastIndexOf(".");
						mExtension = value.Substring(extIndex + 1);
					}
					// if contains a '/' then everthing before
					// it is part of the path so strip it out
					if (value.Contains("/"))
					{
						dirIndex = value.LastIndexOf("/");						
					}

					mFileName = value.Substring(dirIndex+1, extIndex-dirIndex-1);
				}
			}
		}

		public string Extension
		{
			get { return mExtension; }
			set
			{
				int mIndex = value.LastIndexOf(".");
				// check if contains '.'	
				if (value.Contains("."))
				{
					mExtension = value.Substring(mIndex + 1);
				}
				else
				{
					//if contains anythign path related throw an error
					if (value.Contains("/"))
					{
						throw new ArgumentInvalidPathFormatException("Tried to set an extension with no '.' yet had '/'");
					}
					else
					{
						mExtension = value;
					}
				}
			}
		}

		public string FullNamePath
		{
			get { return mPath + mFileName + "." + mExtension; }
			set
			{
				if (!value.Contains("."))
				{
					throw new ArgumentInvalidPathFormatException("Tried to set full path but path did not contain .");
				}

				if (!value.Contains("/"))
				{
					value = "/" + value;
				}
				int dirIndex = value.LastIndexOf("/");
				int extIndex = value.LastIndexOf(".");

				if (extIndex == -1)
					throw new ArgumentInvalidPathFormatException("tried to specify full path file name with no extension ... could be a directory");

				//store the directory
				mPath = value.Substring(0, dirIndex + 1);

				//store the filename
				mFileName = value.Substring(dirIndex + 1, extIndex - dirIndex-1);
				
				//store the extension
				mExtension = value.Substring(extIndex + 1);


			}
		}

	

	}
}
