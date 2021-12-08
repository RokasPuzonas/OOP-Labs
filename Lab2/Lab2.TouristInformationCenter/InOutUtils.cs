using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Lab2.TouristInformationCenter
{
    /// <summary>
    /// Class that stores functions that are related to reading and writing data
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Append the museums from the second register to the first one
        /// </summary>
        /// <param name="register1">First register</param>
        /// <param name="register2">Second register</param>
        private static void AppendRegister(MuseumsRegister register1, MuseumsRegister register2)
        {
            for (int i = 0; i < register2.Count(); i++)
            {
                register1.Add(register2.GetByIndex(i));
            }
        }

        /// <summary>
        /// Decode a list of museums from a given list of lines.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Register of museums</returns>
        public static MuseumsRegister DecodeMuseums(List<string> lines)
        {
            List<Museum> museums = new List<Museum>();
            string city = lines[0];
            string manager = lines[1];
            for (int i = 2; i < lines.Count; i++)
            {
                string line = lines[i];
                string[] values = line.Split(';');
                string name = values[0];
                string type = values[1];
                List<Weekday> workdays = new List<Weekday>();
                if (int.Parse(values[2]) == 1)
                {
                    workdays.Add(Weekday.Monday);
                }
                if (int.Parse(values[3]) == 1)
                {
                    workdays.Add(Weekday.Tuesday);
                }
                if (int.Parse(values[4]) == 1)
                {
                    workdays.Add(Weekday.Wednesday);
                }
                if (int.Parse(values[5]) == 1)
                {
                    workdays.Add(Weekday.Thursday);
                }
                if (int.Parse(values[6]) == 1)
                {
                    workdays.Add(Weekday.Friday);
                }
                if (int.Parse(values[7]) == 1)
                {
                    workdays.Add(Weekday.Saturday);
                }
                if (int.Parse(values[8]) == 1)
                {
                    workdays.Add(Weekday.Sunday);
                }
                double price = double.Parse(values[9]);
                bool hasGuide = int.Parse(values[10]) == 1;

                Museum museum = new Museum(name, city, manager, type, workdays, price, hasGuide);
                museums.Add(museum);
            }
            return new MuseumsRegister(museums);
        }

        /// <summary>
        /// Read and decode a list of museums from a file.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <returns>Register of museums</returns>
        public static MuseumsRegister ReadMuseumsFromCSV(string filename)
        {
            List<string> lines = new List<string>();
            foreach (string line in File.ReadAllLines(filename, Encoding.UTF8))
            {
                lines.Add(line);
            }
            return DecodeMuseums(lines);
        }

        /// <summary>
        /// Read all the entries from a zip file and decode the museums inside the csv entries.
        /// </summary>
        /// <param name="filename">Target filename</param>
        /// <returns>Register of museums</returns>
        public static MuseumsRegister ReadMuseumsFromZIP(string filename)
        {
            MuseumsRegister mainRegister = new MuseumsRegister();

            using (ZipArchive zipFile = ZipFile.Open(filename, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zipFile.Entries)
                {
                    if (!entry.Name.EndsWith(".csv")) continue;
                    List<string> lines = new List<string>();
                    using (StreamReader reader = new StreamReader(entry.Open(), Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            lines.Add(reader.ReadLine());
                        }
                    }

                    MuseumsRegister register = DecodeMuseums(lines);
                    AppendRegister(mainRegister, register);
                }
                    
            }
                
            return mainRegister;
        }

        /// <summary>
        /// Read and decode lists of museums from multiple files and put into a single register.
        /// </summary>
        /// <param name="filenames">Target files</param>
        /// <returns>Register containing museums from all files</returns>
        public static MuseumsRegister ReadMuseums(params string[] filenames)
        {
            MuseumsRegister mainRegister = new MuseumsRegister();
            foreach (string filename in filenames)
            {
                if (filename.EndsWith(".csv"))
                {
                    AppendRegister(mainRegister, ReadMuseumsFromCSV(filename));
                }
                else if(filename.EndsWith(".zip"))
                {
                    AppendRegister(mainRegister, ReadMuseumsFromZIP(filename));
                }
            }
            return mainRegister;
        }

        /// <summary>
        /// Write and encode a list of museums to a file. The file will be in a csv format using ";" as seperators.
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

                lines[i] = String.Join(";", m.City, m.Name, workDays, m.Price);
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Write and encode a list of museums to a file from a register.
        /// </summary>
        /// <param name="filename">Target location</param>
        /// <param name="register">Register containing museums</param>
        public static void WriteMuseums(string filename, MuseumsRegister register)
        {
            List<Museum> museums = new List<Museum>();
            for (int i = 0; i < register.Count(); i++)
            {
                museums.Add(register.GetByIndex(i));
            }
            WriteMuseums(filename, museums);
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

            Console.WriteLine(new string('-', 120));
            Console.WriteLine("| {0,-20} | {1,-10} | {2,-20} | {3,-10} | {4,18} | {5,10} | {6,-4} |", "Vardas", "Miestas", "Atsakingas", "Tipas", "Darbo dienų kiekis", "Kaina", "Turi gidą?");
            Console.WriteLine(new string('-', 120));
            foreach (Museum m in museums)
            {
                Console.WriteLine("| {0,-20} | {1,-10} | {2,-20} | {3,-10} | {4,18} | {5,10:f2} | {6,-10} |", m.Name, m.City, m.Manager, m.Type, m.Workdays.Count, m.Price, m.HasGuide ? "Taip" : "Ne");
            }
            Console.WriteLine(new string('-', 120));
        }

        /// <summary>
        /// Write out a list of museums in a table to the console from a register.
        /// </summary>
        /// <param name="register">Register containing museums</param>
        public static void PrintMuseums(MuseumsRegister register)
        {
            List<Museum> museums = new List<Museum>();
            for (int i = 0; i < register.Count(); i++)
            {
                museums.Add(register.GetByIndex(i));
            }
            PrintMuseums(museums);
        }
    }
}
