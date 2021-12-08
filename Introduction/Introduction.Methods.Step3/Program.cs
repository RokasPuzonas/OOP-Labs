using System;

namespace Introduction.Methods.Step3
{
	class Program
	{
		static void Main(string[] args)
		{
			int z;
			Console.WriteLine("Įveskite z reikšmę:");
			z = int.Parse(Console.ReadLine());
			Program program = new Program();
			if (z - 1 >= 0)
			{
				Console.WriteLine("z={0} f(x)={1}", z, program.RaisePower(z, 1, 0.5));
			}
			else
				Console.WriteLine("z={0} f-ja neegzistuoja", z);
			Console.ReadKey();
		}

		double RaisePower(int value1, int value2, double power)
		{
			return Math.Pow(value1 - value2, power);
		}
	}
}
