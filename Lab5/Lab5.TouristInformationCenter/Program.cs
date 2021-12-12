using System;
using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all museums from initial data files
            LocationsContainer container = InOutUtils.ReadLocations("LocationsKaunas.csv", "LocationsVilnius.csv", "LocationsAlytus.csv");
            Register register = new Register(container);
            Console.WriteLine("Visos vietos:");
            InOutUtils.PrintLocations(register);
            Console.WriteLine();

            int locationCount = register.CountLocationsThatHaveGuides();
            Console.WriteLine("Lankytinų vietų skaičius kurie turi gidus: {0}", locationCount);
            Console.WriteLine();

            List<string> types = register.FindCommonTypesWithGuidesAtWeekends();
            Console.Write("Lankytinų vietų tipai kuriouse galima apsilankyti visuose miestuose savaitgaliais:");
            foreach (string type in types)
            {
                Console.WriteLine("* {0}", type);
            }
            Console.WriteLine();

            /*
            // Write out a list of cities and if they have at least one museum that is free and with a guide
            List<string> cities = register.GetAllCities();
            foreach (string city in cities)
            {
                MuseumsContainer freeMuseumsWithGuide = register
                    .FilterByCity(city)
                    .FilterByPrice(0)
                    .FilterByGuide(true);
                bool passesCriteria = freeMuseumsWithGuide.Count > 0;
                Console.WriteLine("{0}: {1}", city, passesCriteria ? "Taip" : "Ne");
            }
            Console.WriteLine();

            // Find all museums that are the most active
            MuseumsContainer mostActiveMuseums = register.FindMostActiveMuseums();
            Console.WriteLine("Aktyviausi muziejai:");
            InOutUtils.PrintMuseums(mostActiveMuseums);
            Console.WriteLine();

            // Find museums that have duplicate names
            MuseumsContainer museumsWithDuplicateNames = register.FindMuseumsWithDuplicateNames();
            InOutUtils.WriteMuseums("Sutampta.csv", museumsWithDuplicateNames);

            // Find all art museums and sort them
            MuseumsContainer artMuseums = register.FilterByType("Dailė");
            artMuseums.Sort();
            InOutUtils.WriteMuseums("Dailė.csv", artMuseums);
            */
        }
    }
}
