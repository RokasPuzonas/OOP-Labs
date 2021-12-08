using System;

namespace Lab4.LetterFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            char mostFrequent = letters.GetMostFrequent();
            if (mostFrequent != 0)
            {
                Console.WriteLine("Dažniausiai pasikartojanti raidė: {0}", mostFrequent);
            }
            InOut.PrintRepetitions(CFr, letters);
        }
    }
}
