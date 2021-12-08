using System;
using System.Collections.Generic;

namespace Lab2.TouristInformationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all museums from initial data files
            MuseumsRegister register = InOutUtils.ReadMuseums("MuseumsKaunas.csv", "MuseumsVilnius.csv");
            Console.WriteLine("Visi muziejai:");
            InOutUtils.PrintMuseums(register);
            Console.WriteLine();

            // Find all museums that are the most active
            List<Museum> mostActiveMuseums = register.FindMostActiveMuseums();
            Console.WriteLine("Aktyviausi muziejai:");
            InOutUtils.PrintMuseums(mostActiveMuseums);
            Console.WriteLine();

            // Find city which has the most museums with guides
            string mostPopularCityByGuides = register.FindCityWithMostGuides();
            Console.WriteLine("Miestas su daugiausia gidų: {0}", mostPopularCityByGuides);
            Console.WriteLine();

            // Find all art museums that are active
            List<Museum> activeMuseums = register.FilterByActiveMuseums(4);
            List<Museum> activeArtMuseums = MuseumsRegister.FilterByType(activeMuseums, "Dailė");
            InOutUtils.WriteMuseums("Dailė.csv", activeArtMuseums);
        }
    }
}
