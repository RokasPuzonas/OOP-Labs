using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Savarankiskas
{
    class InOutUtils
    {
        public static ApartmentsRegister ReadAparments(string filename)
        {
            List<Apartment> apartments = new List<Apartment>();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                int id = int.Parse(values[0]);
                double area = double.Parse(values[1]);
                int roomCount = int.Parse(values[2]);
                double price = double.Parse(values[3]);
                string phone = values[4];
                Apartment apartment = new Apartment(id, area, roomCount, price, phone);
                apartments.Add(apartment);
            }
            return new ApartmentsRegister(apartments);
        }

        public static void PrintApartments(ApartmentsRegister register)
        {
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0,4} | {1,7} | {2,15} | {3,10} | {4,10} | {5,-13} |", "Num", "Aukštas", "Kambarių kiekis", "Plotas", "Kaina", "Telefonas");
            Console.WriteLine(new string('-', 78));
            for (int i = 0; i < register.Count(); i++)
            {
                Apartment aparment = register.GetApartment(i);
                Console.WriteLine("| {0,4} | {1,7} | {2,15} | {3,10:f2} | {4,10:f2} | {5,-13} |", aparment.Id, aparment.Floor, aparment.RoomCount, aparment.Area, aparment.Price, aparment.Phone);

            }
            Console.WriteLine(new string('-', 78));
        }
        
    }
}
