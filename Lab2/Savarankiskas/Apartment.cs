using System;
using System.Collections.Generic;
using System.Text;

namespace Savarankiskas
{
    /// <summary>
    /// Class used to store revelant information about an apartment
    /// </summary>
    class Apartment
    {
        public int Id { get; set; }
        public double Area { get; set; }
        public int RoomCount { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public int House { get { return (Id - 1) / 27 + 1; } }
        public int Floor { get { return (Id - 1) % 9 + 1; } }
        public Apartment(int id, double area, int roomCount, double price, string phone)
        {
            Id = id;
            Area = area;
            RoomCount = roomCount;
            Price = price;
            Phone = phone;
        }
    }
}
