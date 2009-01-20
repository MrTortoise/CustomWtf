using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Zip
{
	public class ZipFileOpenException : ArgumentException 
	{
		public string Path;

		public ZipFileOpenException()
		{ }

		public ZipFileOpenException(string message)
			: base(message)
		{ }

		public ZipFileOpenException(string message, string thePath)
			: base(message)
		{ Path = thePath; }

		public ZipFileOpenException(string message, Exception inner)
			: base(message, inner)
		{ }

		public ZipFileOpenException(string message, string thePath, Exception inner)
			: base(message, inner)
		{ Path = thePath; }
	}
}
