using System;
using System.Collections.Generic;

namespace Introduction.CharsAndStrings.Step6
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> weekDays = new Dictionary<string, string>()
			{
				{"pirmadienis", "Pirmadienis - sudėtingiausia savaitės diena."},
				{"antradienis", "Antradienis – aktyvių veiksmų, Marso diena."},
				{"trečiadienis", "Trečiadienis – sandoriams sudaryti tinkamiausia diena."},
				{"ketvirtadienis", "Ketvirtadienį reikėtų imtis visuomeninių darbų."},
				{"penktadienis", "Penktadienį lengvai gimsta šedevrai, susitinka mylimieji."},
				{"šeštadienis", "Šeštadienis - savo problemų sprendimo diena."},
				{"sekmadienis", "Sekmadienį reikėtų pradėti naujus darbus, kurti planus."}
			};

			Console.WriteLine("Kokia šiandien savaitės diena?");
			string day = Console.ReadLine().ToLower();
			if(weekDays.ContainsKey(day))
				Console.WriteLine("{0}", weekDays[day]);
			else
				Console.WriteLine("Tokios savaitės dienos pas mus nebūna.");
			Console.ReadKey();
		}
	}
}
