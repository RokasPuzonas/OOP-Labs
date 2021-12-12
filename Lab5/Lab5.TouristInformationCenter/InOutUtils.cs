using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Lab5.TouristInformationCenter
{
    /// <summary>
    /// Class that stores functions that are related to reading and writing data
    /// </summary>
    class InOutUtils
    {
        /// <summary>
        /// Append the locations from the second container to the first one
        /// </summary>
        /// <param name="container1">First container</param>
        /// <param name="container2">Second container</param>
        private static void AppendContainer(LocationsContainer container1, LocationsContainer container2)
        {
            for (int i = 0; i < container2.Count; i++)
            {
                container1.Add(container2.Get(i));
            }
        }

        /// <summary>
        /// Decode a list of locations from a given list of lines.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>Container of locations</returns>
        public static LocationsContainer DecodeLocations(List<string> lines)
        {
            LocationsContainer container = new LocationsContainer(lines.Count-2);
            string city = lines[0];
            string manager = lines[1];
            for (int i = 2; i < lines.Count; i++)
            {
                string line = lines[i];
                string[] values = line.Split(';');
                /* string name = values[0]; */
                /* string type = values[1]; */
                /* List<Weekday> workdays = new List<Weekday>(); */
                /* for (int j = 1; j <= 7; j++) */
                /* { */
                /*     if (int.Parse(values[j + 1]) == 1) */
                /*     { */
                /*         workdays.Add((Weekday)j); */
                /*     } */
                /* } */
                /* double price = double.Parse(values[9]); */
                /* bool hasGuide = int.Parse(values[10]) == 1; */

                /* Location location = new Location(name, city, manager, type, workdays, price, hasGuide); */
                /* container.Add(location); */
            }
            return container;
        }

        /// <summary>
        /// Read and decode a list of locations from a file.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <returns>Container of locations</returns>
        public static LocationsContainer ReadLocationsFromCSV(string filename)
        {
            List<string> lines = new List<string>();
            foreach (string line in File.ReadAllLines(filename, Encoding.UTF8))
            {
                lines.Add(line);
            }
            return DecodeLocations(lines);
        }

        /// <summary>
        /// Read all the entries from a zip file and decode the locations inside the csv entries.
        /// </summary>
        /// <param name="filename">Target filename</param>
        /// <returns>Register of locations</returns>
        public static LocationsContainer ReadLocationsFromZIP(string filename)
        {
            LocationsContainer mainContainer = new LocationsContainer();

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

                    LocationsContainer contaienr = DecodeLocations(lines);
                    AppendContainer(mainContainer, contaienr);
                }

            }

            return mainContainer;
        }

        /// <summary>
        /// Read and decode lists of locations from multiple files and put into a single register.
        /// </summary>
        /// <param name="filenames">Target files</param>
        /// <returns>Register containing locations from all files</returns>
        public static LocationsContainer ReadLocations(params string[] filenames)
        {
            LocationsContainer mainContainer = new LocationsContainer();
            foreach (string filename in filenames)
            {
                if (filename.EndsWith(".csv"))
                {
                    AppendContainer(mainContainer, ReadLocationsFromCSV(filename));
                }
                else if(filename.EndsWith(".zip"))
                {
                    AppendContainer(mainContainer, ReadLocationsFromZIP(filename));
                }
            }
            return mainContainer;
        }

        private static string CreateLocationLine(Location location)
        {
/*             string workDays = ""; */
/*             workDays += location.Workdays.Contains(Weekday.Monday) ? "1" : "0"; */
/*             workDays += location.Workdays.Contains(Weekday.Tuesday) ? ";1" : ";0"; */
/*             workDays += location.Workdays.Contains(Weekday.Wednesday) ? ";1" : ";0"; */
/*             workDays += location.Workdays.Contains(Weekday.Thursday) ? ";1" : ";0"; */
/*             workDays += location.Workdays.Contains(Weekday.Friday) ? ";1" : ";0"; */
/*             workDays += location.Workdays.Contains(Weekday.Saturday) ? ";1" : ";0"; */
/*             workDays += location.Workdays.Contains(Weekday.Sunday) ? ";1" : ";0"; */
/*  */
/*             return String.Join(";", location.City, location.Name, workDays, location.Price); */
            return "";
        }

        /// <summary>
        /// Write and encode a list of locations to a file. The file will be in a csv format using ";" as seperators.
        /// </summary>
        /// <param name="filename">Target file</param>
        /// <param name="container">Container of locations</param>
        public static void WriteLocations(string filename, LocationsContainer container)
        {
            string[] lines = new string[container.Count];
            for (int i = 0; i < container.Count; i++)
            {
                Location location = container.Get(i);
                lines[i] = CreateLocationLine(location);
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Write and encode a list of locations to a file from a register.
        /// </summary>
        /// <param name="filename">Target location</param>
        /// <param name="register">Register containing locations</param>
        public static void WriteLocations(string filename, Register register)
        {
            int n = register.Count();
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                Location location = register.GetByIndex(i);
                lines[i] = CreateLocationLine(location);
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Write out a container of locations in a table to the console.
        /// </summary>
        /// <param name="container">Container of locations</param>
        public static void PrintLocations(LocationsContainer container)
        {
            if (container.Count == 0)
            {
                Console.WriteLine("Nėra");
                return;
            }

            Console.WriteLine(new string('-', 123));
            /* Console.WriteLine("| {0,-20} | {1,-10} | {2,-20} | {3,-10} | {4,18} | {5,13} | {6,-4} |", "Vardas", "Miestas", "Atsakingas", "Tipas", "Darbo dienų kiekis", "Kaina", "Turi gidą?"); */
            Console.WriteLine(new string('-', 123));
            for (int i = 0; i < container.Count; i++)
            {
                Location l = container.Get(i);
                /* Console.WriteLine("| {0,-20} | {1,-10} | {2,-20} | {3,-10} | {4,18} | {5,13:f2} | {6,-10} |", l.Name, l.City, l.Manager, l.Type, l.Workdays.Count, l.Price, l.HasGuide ? "Taip" : "Ne"); */
            }
            Console.WriteLine(new string('-', 123));
        }

        /// <summary>
        /// Write out a list of locations in a table to the console from a register.
        /// </summary>
        /// <param name="register">Register containing locations</param>
        public static void PrintLocations(Register register)
        {
            LocationsContainer locations = new LocationsContainer();
            for (int i = 0; i < register.Count(); i++)
            {
                locations.Add(register.GetByIndex(i));
            }
            PrintLocations(locations);
        }
    }
}
