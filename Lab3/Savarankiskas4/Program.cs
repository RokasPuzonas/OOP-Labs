using System;
using System.Collections.Generic;

namespace Savarankiskas4
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsContainer container = InOutUtils.ReadStudents("Chemijos.csv", "Elektros.csv", "Informatikos.csv");
            InOutUtils.PrintStudents("Studentai", container);
            Console.WriteLine();

            StudentsRegister register = new StudentsRegister(container);
            List<Tuple<string, float>> averages = register.FindGradesAverages();
            Console.WriteLine("Grupių pažymių vidurkiai:");
            foreach (Tuple<string, float> tuple in averages)
            {
                Console.WriteLine("{0}: {1}", tuple.Item1, tuple.Item2);
            }
        }
    }
}

