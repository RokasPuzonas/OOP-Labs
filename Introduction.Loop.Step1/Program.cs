using System;

namespace Introduction.Loop.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skaičiai nuo 1 iki 10 ir jų kvadratai:");
            for (int i = 1; i < 11; i++)
                Console.WriteLine("{0} {1}", i, i * i);
            Console.ReadKey();
        }
    }
}