using System;

namespace Introduction._4Savarankiskas
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Koks tavo vardas? ");
			string name = Console.ReadLine().TrimEnd();
			if (name.EndsWith("as")) {
				name = name.Substring(0, name.Length-2) + "ai";
			} else if (name.EndsWith("is")) {
				name = name.Substring(0, name.Length-2) + "i";
			} else if (name.EndsWith("ys")) {
				name = name.Substring(0, name.Length-2) + "į";
			} else if (name.EndsWith("a")) {
                // Nothing needs to change
				/* name = name.Substring(0, name.Length-1) + "a"; */
			} else if (name.EndsWith("ė")) {
				name = name.Substring(0, name.Length-1) + "e";
			}
			Console.WriteLine("Labas, {0}!", name);
		}
	}
}
