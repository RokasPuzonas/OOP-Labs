using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4.FirstEqualLast
{
	public class TaskUtils
	{
		/** Reads file and finds the number of words having same the first and
			the last letters.
			@param fin – name of data file 
			@param punctuation – punctuation marks to separate words */
		public static int Process(string fin, string punctuation)
		{
			string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
			int equal = 0;
			foreach (string line in lines)
				if (line.Length > 0)
					equal += FirstEqualLast(line, punctuation);
				return equal;
			}

		/** Splits line into words and counts the words having same the first
			and the last letters.
			@param line – string of data
			@param punctuation – punctuation marks to separate words */
		private static int FirstEqualLast (string line, string punctuation)
		{
			string[] parts = Regex.Split(line.ToLower(), punctuation);
			int equal = 0;
			foreach (string word in parts)
				if(word.Length > 0) // empty words at the end of line
					if (word[0] == word[word.Length - 1])
						equal++;
			return equal;
		}

		/** Reads file and finds the number of words having same the first and
			the last letters.
			@param fin – name of data file
			@param punctuation – punctuation marks to separate words */
		public static int Process(string fin, char[] punctuation)
		{
			string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
			int equal = 0;
			foreach (string line in lines)
				if (line.Length > 0)
					equal += FirstEqualLast(line, punctuation);
			return equal;
		}

		/** Splits line into words and counts the words having same the first and the
			last letters.
			@param line – string of data
			@param punctuation – punctuation marks to separate words */
		private static int FirstEqualLast (string line, char[] punctuation)
		{
			string[] parts = line.ToLower().Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
			int equal = 0;
			foreach (string word in parts)
				if (word[0] == word[word.Length - 1])
					equal++;
			return equal;
		}
	}
}
