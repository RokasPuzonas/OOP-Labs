using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab4.Raides
{
    static class InOut
    {
        /** Prints repetition of letters using two columns into a given file.
        @param fout – name of the file for the output
        @param letters – object having letters and their repetitions */
        public static void PrintRepetitions(string fout, LettersFrequency letters)
        {
            using (var writer = File.CreateText(fout))
            {
                foreach (var pair in letters.GetOrderedFrequencies())
                {
                    writer.WriteLine("{0, 3:c} {1, 4:d}", pair.Item1, pair.Item2);
                }
            }
        }

        /** Inputs from the given data file and counts repetition of letters.
         @param fin – name of data file
         @param letters – object having letters and their repetitions*/
        public static void Repetitions(string fin, LettersFrequency letters)
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    letters.line = line;
                    letters.CountLetters();
                }
            }
        }
    }
}
