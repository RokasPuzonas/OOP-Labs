using System;
using System.Collections.Generic;

namespace Savarankiskas
{
    class Program
    {
        static void Main(string[] args)
        {
            ApartmentsRegister register = InOutUtils.ReadAparments("Apartments.csv");
            Console.WriteLine("Visi butai:");
            InOutUtils.PrintApartments(register);
            Console.WriteLine();

            Console.WriteLine("Įveskite norimą kambarių kiekį:");
            int roomCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite maksimalią buto kainą:");
            double maxPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite žemiausią norimą aukštą [1-9]:");
            int minFloor = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite aukščiausią norimą aukštą [{0}-9]:", minFloor);
            int maxFloor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            List<Apartment> filtered = register.FilterByRoomCount(roomCount);
            filtered = ApartmentsRegister.FilterByPrice(filtered, maxPrice);
            filtered = ApartmentsRegister.FilterByFloor(filtered, minFloor, maxFloor);

            ApartmentsRegister filteredRegister = new ApartmentsRegister(filtered);
            Console.WriteLine("Atrinkti butai:");
            InOutUtils.PrintApartments(filteredRegister);
        }
    }
}
