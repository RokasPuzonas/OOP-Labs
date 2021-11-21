using System.Text;
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
		private static void AddSurname(string line, string punctuation, string name, string surname, StringBuilder newLine)
		{
			string addLine = " " + line + " ";
			int init = 1;
			int ind = addLine.IndexOf(name);
			while (ind != -1)
			{
				if (punctuation.IndexOf(addLine[ind - 1]) != -1 && punctuation.IndexOf(addLine[ind + name.Length]) != -1)
				{
					newLine.Append(addLine.Substring(init, ind + name.Length - init));
					newLine.Append(surname);
					init = ind + name.Length;
				}
				ind = addLine.IndexOf(name, ind + 1);
			}
			newLine.Append(line.Substring(init - 1));
		}

		/** Reads file and adds given surname to the given name.
		 @param fin – name of data file
		 @param fout – name of result file
		 @param punctuation – punctuation marks to separate words
		 @param name – word to find
		 @param surname – given word to add */
		public static void Process(string fin, string fout, string punctuation, string name, string surname)
		{
			string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
			using (var writer = File.CreateText(fout))
			{
				foreach (string line in lines)
				{
					StringBuilder newLine = new StringBuilder();
					AddSurname(line, punctuation, name, surname, newLine);
					writer.WriteLine(newLine);
				}
			}
		}
	}
}
