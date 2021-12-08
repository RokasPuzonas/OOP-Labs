using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Lab3.TouristInformationCenterExtra
{
    /// <summary>
    /// Class that stores functions that are related to reading and writing data
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Append the museums from the second container to the first one
        /// </summary>
        /// <param name="container1">First container</param>
        /// <param name="container2">Second container</param>
        private static void AppendContainer(MuseumsContainer container1, MuseumsContainer container2)
        {
            for (int i = 0; i < container2.Count; i++)
            {
                container1.Add(container2.Get(i));
            }
        }

        /// <summary>
        /// Decode a single museum from a string
        /// </summary>
        /// <param name="city">Target city</param>
        /// <param name="manager">Target manager</param>
        /// <param name="encoded">Encoded string</param>
        /// <returns>A decode museum</returns>
        public static Museum DecodeMusem(string city, string manager, string encoded)
        {
            string[] values = encoded.Split(';');
            string name = values[0];
            string type = values[1];
            List<Weekday> workdays = new List<Weekday>();
            for (int i = 1; i <= 7; i++)
            {
                if (int.Parse(values[i + 1]) == 1)
                {
                    workdays.Add((Weekday)i);
                }
            }
            double price = double.Parse(values[9]);
            bool hasGuide = int.Parse(values[10]) == 1;

            return new Museum(name, city, manager, type, workdays, price, hasGuide);
        }

        /// <summary>
        /// Decode a list of museums from a given list of lines.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Container of museums</returns>
        public static MuseumsContainer DecodeMuseums(List<string> lines)
        {
            MuseumsContainer container = new MuseumsContainer(lines.Count-2);
            string city = lines[0];
            string manager = lines[1];
            for (int i = 2; i < lines.Count; i++)
            {
                Museum museum = DecodeMusem(city, manager, lines[i]);
                container.Add(museum);
            } 
            return container;
        }

        /// <summary>
        /// Read and decode a list of museums from a file.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <returns>Container of museums</returns>
        public static MuseumsContainer ReadMuseumsFromCSV(string filename)
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
        public static MuseumsContainer ReadMuseumsFromZIP(string filename)
        {
            MuseumsContainer mainContainer = new MuseumsContainer();

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

                    MuseumsContainer contaienr = DecodeMuseums(lines);
                    AppendContainer(mainContainer, contaienr);
                }
                    
            }
                
            return mainContainer;
        }

        /// <summary>
        /// Read and decode lists of museums from multiple files and put into a single register.
        /// </summary>
        /// <param name="filenames">Target files</param>
        /// <returns>Register containing museums from all files</returns>
        public static MuseumsContainer ReadMuseums(params string[] filenames)
        {
            MuseumsContainer mainContainer = new MuseumsContainer();
            foreach (string filename in filenames)
            {
                if (filename.EndsWith(".csv"))
                {
                    AppendContainer(mainContainer, ReadMuseumsFromCSV(filename));
                }
                else if(filename.EndsWith(".zip"))
                {
                    AppendContainer(mainContainer, ReadMuseumsFromZIP(filename));
                }
            }
            return mainContainer;
        }

        private static string CreateMuseumLine(Museum museum)
        {
            string workDays = "";
            workDays += museum.Workdays.Contains(Weekday.Monday) ? "1" : "0";
            workDays += museum.Workdays.Contains(Weekday.Tuesday) ? ";1" : ";0";
            workDays += museum.Workdays.Contains(Weekday.Wednesday) ? ";1" : ";0";
            workDays += museum.Workdays.Contains(Weekday.Thursday) ? ";1" : ";0";
            workDays += museum.Workdays.Contains(Weekday.Friday) ? ";1" : ";0";
            workDays += museum.Workdays.Contains(Weekday.Saturday) ? ";1" : ";0";
            workDays += museum.Workdays.Contains(Weekday.Sunday) ? ";1" : ";0";

            return String.Join(";", museum.City, museum.Name, workDays, museum.Price);
        }
        
        /// <summary>
        /// Write and encode a list of museums to a file. The file will be in a csv format using ";" as seperators.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <param name="container">Container of museums</param>
        public static void WriteMuseums(string filename, MuseumsContainer container)
        {
            string[] lines = new string[container.Count];
            for (int i = 0; i < container.Count; i++)
            {
                Museum museum = container.Get(i);
                lines[i] = CreateMuseumLine(museum);
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
            int n = register.Count();
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                Museum museum = register.GetByIndex(i);
                lines[i] = CreateMuseumLine(museum);
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Write out a container of museums in a table to the console.
        /// </summary>
        /// <param name="container">Container of museums</param>
        public static void PrintMuseums(MuseumsContainer container)
        {
            if (container.Count == 0)
            {
                Console.WriteLine("Nėra");
                return;
            }

            Console.WriteLine(new string('-', 115));
            Console.WriteLine("| {0,20} | {1,-10} | {2,20} | {3,-10} | {4,-18} | {5,-3} | {6,-4} |", "Vardas", "Miestas", "Atsakingas", "Tipas", "Darbo dienų kiekis", "Kaina", "Turi gidą?");
            Console.WriteLine(new string('-', 115));
            for (int i = 0; i < container.Count; i++)
            {
                Museum m = container.Get(i);
                Console.WriteLine("| {0,20} | {1,-10} | {2, 20} | {3,-10} | {4,-18} | {5,-5:f2} | {6,-10} |", m.Name, m.City, m.Manager, m.Type, m.Workdays.Count, m.Price, m.HasGuide ? "Taip" : "Ne");
            }
            Console.WriteLine(new string('-', 115));
        }

        /// <summary>
        /// Write out a list of museums in a table to the console from a register.
        /// </summary>
        /// <param name="register">Register containing museums</param>
        public static void PrintMuseums(MuseumsRegister register)
        {
            MuseumsContainer museums = new MuseumsContainer();
            for (int i = 0; i < register.Count(); i++)
            {
                museums.Add(register.GetByIndex(i));
            }
            PrintMuseums(museums);
        }
    }
}
