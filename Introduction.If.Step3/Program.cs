using System;

namespace Introduction.If.Step3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite plotį: ");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite aukštį: ");
            int height = int.Parse(Console.ReadLine());
            char character;
            Console.WriteLine("Įveskite spausdinamą simbolį: ");
            character = (char)Console.Read();
            for (int i = 1; i <= width * height; i++)
                if (i % width == 0)
                    Console.WriteLine(character);
                else
                    Console.Write(character);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}