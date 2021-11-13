using System;
using System.Collections.Generic;

namespace Lab1.TouristInformationCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all museums from initial data file.
            List<Museum> museums = InOutUtils.ReadMuseums("Museums.csv");
            Console.WriteLine("Visi muziejai:");
            InOutUtils.PrintMuseums(museums);
            Console.WriteLine();

            // Filter out museums that are free and a guide. And output those museums to the console.
            Console.WriteLine("Muziejai kurie yra nemokami ir turi gidą:");
            InOutUtils.PrintMuseums(TaskUtils.FilterByFreeAndWithGuide(museums));
            Console.WriteLine();

            // Filter out museums that are "active". And output those museums to the console.
            Console.WriteLine("Muziejai kurie dirba bent 5 kartus per savaitę:");
            InOutUtils.PrintMuseums(TaskUtils.FilterByActiveMuseums(museums));
            Console.WriteLine();

            // Filter out museums that are from "non-popular" cities. And save them to a file.
            InOutUtils.WriteMuseums("Atrinkti.csv", TaskUtils.FilterByNonPopularCity(museums));
        }
    }
}
