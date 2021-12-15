using System;
using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationsContainer container = InOutUtils.ReadLocations("LocationsKaunas.csv", "LocationsVilnius.csv", "LocationsAlytus.csv");
            Register register = new Register(container);
            Console.WriteLine("Visos vietos:");
            InOutUtils.PrintLocations(register);
            Console.WriteLine();

            int locationCount = register.CountLocationsThatHaveGuides();
            Console.WriteLine("Lankytinų vietų skaičius kurie turi gidus: {0}", locationCount);
            Console.WriteLine();

            List<string> types = register.FindCommonTypesWithGuidesAtWeekends();
            Console.WriteLine("Lankytinų vietų tipai kuriouse galima apsilankyti visuose miestuose savaitgaliais:");
            foreach (string type in types)
            {
                Console.WriteLine("* {0}", type);
            }
            Console.WriteLine();

            Console.Write("Įveskite norimas autorius: ");
            //string inputAuthor = Console.ReadLine();
            string inputAuthor = "Tas Klebonas";
            LocationsContainer locationsByAuthor = register.FindLocationsByAuthor(inputAuthor);
            locationsByAuthor.Sort(new LocationsComparatorByNameAddress());
            InOutUtils.WriteStatues("PaminklaiAutorius.csv", locationsByAuthor);

            InOutUtils.WriteLocations("Po1990.csv", register.FindLocationsAfterYear(1990));
        }
    }
}
