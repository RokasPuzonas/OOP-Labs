using System;

namespace Introduction.CharsAndStrings.Step3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Įveskite raidę raidžių intervalo pradžiai");
			char startChar = Console.ReadLine()[0];
			Console.WriteLine("Įveskite raidę raidžių intervalo pabaigai");
			char endChar = (char)Console.Read();
			for (char ch = startChar; ch <= endChar; ch++)
				Console.WriteLine("{0} - {1}", ch, (int)ch);
			Console.ReadKey();
		}
	}
}
