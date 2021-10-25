using System;

namespace Introduction.Methods.Step2
{
    class Program
    {
			static void Main(string[] args)
			{
				double functionResult;
				int a;
				double x;
				Console.WriteLine("Įveskite a reikšmę:");
				a = int.Parse(Console.ReadLine());
				Console.WriteLine("Įveskite x reikšmę:");
				x = double.Parse(Console.ReadLine());
				Program program = new Program();
				functionResult = program.CalculateValue(a, x);
				Console.WriteLine(" Reikšmė a = {0}, reikšmė x = {1}, fx = {2}", a, x,
				functionResult);
				Console.ReadKey();
			}

			double CalculateValue(int a, double x)
			{
				double value;
				if (x <= 0)
					value = a * Math.Exp(-x);
				else if (x < 1)
					value = 5 * a * x - 7;
				else
					value = Math.Pow(x + 1, 0.5);
				return value;
			}
    }
}
