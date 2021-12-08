using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1._1Savarankiskas
{
    class InOutUtils
    {
        public static List<Tourist> ReadTourists(string fileName)
        {
            List<Tourist> tourists = new List<Tourist>();
						string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
						foreach (string line in lines)
						{
							string[] values = line.Split(";");
							string name = values[0];
							string surname = values[1];
							double money = double.Parse(values[2]);
							Tourist tourist = new Tourist(name, surname, money);
							tourists.Add(tourist);
						}
            return tourists;
        }

				public static void PrintTourists(List<Tourist> tourists)
				{
					Console.WriteLine(new string('-', 47));
					Console.WriteLine("| {0,-12} | {1,-12} | {2,-13} |", "Vardas", "Pavardė", "Pinigai");
					Console.WriteLine(new string('-', 47));
					foreach (Tourist tourist in tourists)
					{
						Console.WriteLine("| {0,-12} | {1,-12} | {2,-13:c2} |", tourist.Name, tourist.Surname, tourist.Money);
					}
					Console.WriteLine(new string('-', 47));
				}
    }
}

