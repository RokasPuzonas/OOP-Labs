using System;

namespace Introduction.Loop.Step6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite nuo kurio skaičiaus skaičiuoti: ");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite iki kurio skaičiaus skaičiuoti: ");
            int to = int.Parse(Console.ReadLine());

            Console.WriteLine("Skaičiai nuo {0} iki {1} ir jų kvadratai ir kūbai:", from, to);
            for (int i = from; i <= to; i++)
                Console.WriteLine("{0} {1} {2}", i, i * i, i * i * i);
            
            // Determine how many times the for loop got executed
            Console.WriteLine("Skaičiavimų kiekis: {0}", to - from + 1);
            Console.ReadKey();
        }
    }
}