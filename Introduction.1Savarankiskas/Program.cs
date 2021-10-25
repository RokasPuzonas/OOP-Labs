using System;

namespace Introduction._1Savarankiskas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite simbolių kiekį: ");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite vienos eilutės simbolių kiekį: ");
            int perLineCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite spausdinamą simbolį: ");
            char character = (char)Console.Read();

            for (int i = 0; i < Math.Ceiling((double)count/perLineCount); i++)
            {
                for (int j = 0; j < Math.Min(perLineCount, count-perLineCount * i); j++)
                    Console.Write(character);
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
