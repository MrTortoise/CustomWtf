using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Exceptions
{
	public class ArgumentInvalidPathFormatException : ArgumentException 
	{
		public string Path;

		public ArgumentInvalidPathFormatException()
		{ }

		public ArgumentInvalidPathFormatException(string message)
			: base(message)
		{ }

		public ArgumentInvalidPathFormatException(string message, string thePath)
			: base(message)
		{ Path = thePath; }

		public ArgumentInvalidPathFormatException(string message, Exception inner)
			: base(message, inner)
		{ }

		public ArgumentInvalidPathFormatException(string message, string thePath, Exception inner)
			: base(message, inner)
		{ Path = thePath; }
	}
}
