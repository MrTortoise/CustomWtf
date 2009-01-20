using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.ExtensionMethods
{
	public static class Extensions
	{
		/// <summary>
		/// Returns the number of times a character pattern is repeated in a string
		/// </summary>
		/// <param name="theWord">The array of chars to be searched</param>
		/// <param name="theCharacters">the character pattern to count</param>
		/// <returns></returns>
		public static int Count(this string theWord, string theCharacters)
		{
			if ((theWord.Length == 0) || (theCharacters.Length == 0))
				return 0;
			if (theCharacters.Length > theWord.Length)
				return 0;
			
			int SearchLength = theCharacters.Length;
			int wordLength = theWord.Length;

			int count = 0;

			for (int i = 0; i < wordLength; i++)
			{
				if (theWord.Substring(i).StartsWith(theCharacters))
					count++;
			}
			return count;
		}
	}
}
