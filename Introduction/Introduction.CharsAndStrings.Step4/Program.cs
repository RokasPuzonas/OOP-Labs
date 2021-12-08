using System;

namespace Introduction.CharsAndStrings.Step4
{
	class Program
	{
		static void Main(string[] args)
		{
			string day;
			Console.WriteLine("Kokia šiandien savaitės diena?");
			day = Console.ReadLine();
			if (day == "pirmadienis")
				Console.WriteLine("Pirmadienis - sudėtingiausia savaitės diena.");
			else if (day == "antradienis")
				Console.WriteLine("Antradienis – aktyvių veiksmų, Marso diena.");
			else if (day == "trečiadienis")
				Console.WriteLine("Trečiadienis – sandoriams sudaryti tinkamiausia diena.");
			else if (day == "ketvirtadienis")
				Console.WriteLine("Ketvirtadienį reikėtų imtis visuomeninių darbų.");
			else if (day == "penktadienis")
				Console.WriteLine("Penktadienį lengvai gimsta šedevrai, susitinka mylimieji.");
			else if (day == "šeštadienis")
				Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
			else if (day == "sekmadienis")
				Console.WriteLine("Sekmadienį reikėtų pradėti naujus darbus.");
			else
				Console.WriteLine("Tokios savaitės dienos pas mus nebūna.");
			Console.ReadKey();
		}
	}
}
