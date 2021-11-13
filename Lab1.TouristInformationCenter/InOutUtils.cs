using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1.TouristInformationCenter
{
    /// <summary>
    /// Class that stores functions that are related to reading and writing data
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Read and decode a list of museums from a file. The file must be in a csv format using ";" as seperators.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <returns>List of museums</returns>
        public static List<Museum> ReadMuseums(string filename)
        {
            List<Museum> museums = new List<Museum>();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string name = values[0];
                string city = values[1];
                string type = values[2];
                List<Weekday> workdays = new List<Weekday>();
                if (int.Parse(values[3]) == 1)
                {
                    workdays.Add(Weekday.Monday);
                }
                if (int.Parse(values[4]) == 1)
                {
                    workdays.Add(Weekday.Tuesday);
                }
                if (int.Parse(values[5]) == 1)
                {
                    workdays.Add(Weekday.Wednesday);
                }
                if (int.Parse(values[6]) == 1)
                {
                    workdays.Add(Weekday.Thursday);
                }
                if (int.Parse(values[7]) == 1)
                {
                    workdays.Add(Weekday.Friday);
                }
                if (int.Parse(values[8]) == 1)
                {
                    workdays.Add(Weekday.Saturday);
                }
                if (int.Parse(values[9]) == 1)
                {
                    workdays.Add(Weekday.Sunday);
                }
                double price = double.Parse(values[10]);
                bool hasGuide = int.Parse(values[11]) == 1;

                Museum museum = new Museum(name, city, type, workdays, price, hasGuide);
                museums.Add(museum);
            }
            return museums;
        }

        /// <summary>
        /// Write and encodes a list of museums to a file. The file will be in a csv format using ";" as seperators.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <param name="museums">List of museums</param>
        public static void WriteMuseums(string filename, List<Museum> museums)
        {
            string[] lines = new string[museums.Count];
            for (int i = 0; i < museums.Count; i++)
            {
                Museum m = museums[i];
                string workDays = "";
                workDays += m.Workdays.Contains(Weekday.Monday) ? "1" : "0";
                workDays += m.Workdays.Contains(Weekday.Tuesday) ? ";1" : ";0";
                workDays += m.Workdays.Contains(Weekday.Wednesday) ? ";1" : ";0";
                workDays += m.Workdays.Contains(Weekday.Thursday) ? ";1" : ";0";
                workDays += m.Workdays.Contains(Weekday.Friday) ? ";1" : ";0";
                workDays += m.Workdays.Contains(Weekday.Saturday) ? ";1" : ";0";
                workDays += m.Workdays.Contains(Weekday.Sunday) ?  ";1" : ";0";

                lines[i] = String.Join(";", m.Name, m.City, m.Type, workDays, m.Price, m.HasGuide ? '1' : '0');
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Write out a list of museums in a table to the console.
        /// </summary>
        /// <param name="museums">List of museums</param>
        public static void PrintMuseums(List<Museum> museums)
        {
            if (museums.Count == 0)
            {
                Console.WriteLine("Nėra");
                return;
            }

            Console.WriteLine(new string('-', 97));
            Console.WriteLine("| {0,20} | {1,-15} | {2,-10} | {3,-18} | {4,-3} | {5,-4} |", "Vardas", "Miestas", "Tipas", "Darbo dienų kiekis", "Kaina", "Turi gidą?");
            Console.WriteLine(new string('-', 97));
            foreach (Museum m in museums)
            {
                Console.WriteLine("| {0,20} | {1,-15} | {2,-10} | {3,-18} | {4,-5:f2} | {5,-10} |", m.Name, m.City, m.Type, m.Workdays.Count, m.Price, m.HasGuide ? "Taip" : "Ne");
            }
            Console.WriteLine(new string('-', 97));
        }
    }
}
