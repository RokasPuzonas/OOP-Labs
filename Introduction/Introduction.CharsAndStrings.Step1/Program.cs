using System;

namespace Introduction.CharsAndStrings.Step1
{
	class Program
	{
		static void Main(string[] args)
		{
			for (char ch = 'a'; ch <= 'z'; ch++)
				Console.Write("{0} ", ch);
			Console.WriteLine("");
			Console.ReadKey();
		}
	}
}
