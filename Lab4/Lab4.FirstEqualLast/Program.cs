﻿using System;
using System.Collections.Generic;

namespace Lab4.FirstEqualLast
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string CFd = "Duomenys.txt";
			string punctuation = "[\\s,.;:!?()\\-]+";
			Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, punctuation));
		}
	}
}
