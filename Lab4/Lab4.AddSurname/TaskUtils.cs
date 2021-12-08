using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab4.AddSurname
{
	public class TaskUtils
	{
		/** Finds name in the line and constructs new line appending given surname.
		 @param line – string of data
		 @param punctuation – punctuation marks to separate words
		 @param name – word to find
		 @param surname – given word to add
		 @param newLine – string of result */
		private static string AddSurname(string line, string punctuation, string name, string surname)
		{
			StringBuilder newLine = new StringBuilder();
			string addLine = " " + line + " ";
			int init = 1;
			int ind = addLine.IndexOf(name);
			while (ind != -1)
			{
				if (punctuation.IndexOf(addLine[ind - 1]) != -1 && punctuation.IndexOf(addLine[ind + name.Length]) != -1)
				{
					newLine.Append(addLine.Substring(init, ind + name.Length - init));
					newLine.Append(" ");
					newLine.Append(surname);
					init = ind + name.Length;
				}
				ind = addLine.IndexOf(name, ind + 1);
			}
			newLine.Append(line.Substring(init - 1));

			return newLine.ToString();
		}

		/** Reads file and adds given surname to the given name.
		 @param fin – name of data file
		 @param fout – name of result file
		 @param punctuation – punctuation marks to separate words
		 @param name – word to find
		 @param surname – given word to add */
		public static void ProcessAddSurname(string fin, string fout, string punctuation, string name, string surname)
		{
			string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
			using (var writer = File.CreateText(fout))
			{
				foreach (string line in lines)
				{
					string newLine = AddSurname(line, punctuation, name, surname);
					writer.WriteLine(newLine);
				}
			}
		}

		public static string RemoveWord(string line, string punctuation, string word)
		{
            string pattern = string.Format(@"(^|[{0}]+){1}($|[{0}]+)", Regex.Escape(punctuation), Regex.Escape(word));
            return Regex.Replace(line, pattern, "$1");
		}

		public static void ProcessRemoveWord(string fin, string fout, string punctuation, string word)
		{
			using (StreamWriter writer = File.CreateText(fout))
			{
				using (StreamReader reader = new StreamReader(fin))
				{
					string line = string.Empty;
					while ((line = reader.ReadLine()) != null) 
					{
						writer.WriteLine(RemoveWord(line, punctuation, word));
					}
				}
			}
		}
	}
}
