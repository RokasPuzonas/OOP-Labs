using System;
using System.Collections.Generic;

namespace Lab4.RemoveLines
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            List<int> lines = InOut.LongestLines(CFd);
            InOut.RemoveLines(CFd, CFr, lines);
            foreach (int line in lines)
            {
                Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", line + 1);
            }
        }
    }
}
