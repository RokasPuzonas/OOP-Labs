using System;
using System.Text;
using System.IO;

namespace Lab4.RemoveVowels
{
	class TaskUtils
	{
		/** Finds the longest word in the line.
		 @param line – string of data
		 @param punctuation – punctuation marks to separate words */
		private static string LongestWord(string line, char[] punctuation)
			{
			string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
			string longestWord="";
			foreach (string word in parts)
				if (word.Length > longestWord.Length)
					longestWord = word;
			return longestWord;
		}

		/** Removes vowels from the given word.
		 @param line – word with possible vowels
		 @param vowels – vowels of the alphabet */
		private static StringBuilder RemoveVowels(string line, string vowels)
		{
			StringBuilder newLine = new StringBuilder();
			for (int i = 0; i < line.Length; i++)
				if (vowels.IndexOf(line[i]) == -1)
					newLine.Append(line[i]);
			return newLine;
		}

		/** Reads file, removes vowels from the longest word, creates files of
		results and of information.
		 @param fin – name of data file
		 @param fout – name of result file
		 @param finfo – name of informative file
		 @param punctuation – punctuation marks to separate words
		 @param vowels – vowels of the alphabet */
		public static void Process(string fin, string fout, string finfo, char[] punctuation, string vowels)
		{
			string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
			string dashes = new string('-', 38);
			using (var writerF = File.CreateText(fout))
			{
				using (var writerI = File.CreateText(finfo))
				{
					writerI.WriteLine(dashes);
					writerI.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
					writerI.WriteLine(dashes);
					foreach (string line in lines)
					{
						if (line.Length > 0)
						{
							string longestWord = LongestWord(line, punctuation);
							string wordNoVowels = RemoveVowels(longestWord, vowels).ToString();
							writerI.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |",
							longestWord, line.IndexOf(longestWord), longestWord.Length);
							string newLine = line.Replace(longestWord, wordNoVowels);
							// The shortest word cannot be replaced this way.
							// It can be a part of the other word; solution is 4.5 subsection.
							writerF.WriteLine(newLine);
						}
						else
							 writerF.WriteLine(line);
					}
					writerI.WriteLine(dashes);
			 }
		 }
		}
	}
}

