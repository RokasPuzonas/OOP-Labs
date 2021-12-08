
namespace Lab4.AddSurname
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string CFd = "Duomenys.txt";
			const string CFr = "Rezultatai.txt";
			string punctuation = " .,!?:;()\t'";
			string name = "Arvydas";
			string surname = "Sabonis";
			TaskUtils.ProcessAddSurname(CFd, CFr, punctuation, name, surname);
			/* TaskUtils.ProcessRemoveWord(CFd, CFr, punctuation, name); */
		}
	}
}
