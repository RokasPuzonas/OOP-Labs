using System;

// Variant 8.
// f1(x) = 1/(x-5)
// f2(x) = Math.Sqrt(x+5)
// f3(x) = Math.Pow(x+3, 2)
// condition 1: -3 <= x <= 0
// condition 2: 0 < x <= 5
namespace Introduction._2Savarankiskas
{
		class Program
		{
				static void Main(string[] args)
				{
						double result;
						Console.WriteLine("Įveskite x reikšmę: ");
						int x = int.Parse(Console.ReadLine());
						if (-3 <= x && x <= 0)
						{
							result = 1.0/(x - 5);
						}
						else if (0 < x && x <= 5)
						{
							result = Math.Sqrt(x+5);
						}
						else
						{
							result = Math.Pow(x+3, 2);
						}
						Console.WriteLine(" Reikšmė x = {0}, fx = {1}", x, result);
				}
		}
}
