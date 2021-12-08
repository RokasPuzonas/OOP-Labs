using System;

namespace Introduction.If.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            char character;
            Console.WriteLine("Įveskite spausdinamą simbolį");
            character = (char)Console.Read();
            for (int i = 1; i < 51; i++)
                if (i % 5 == 0)
                    Console.WriteLine(character);
                else
                    Console.Write(character);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}