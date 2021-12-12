using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    /// <summary>
    /// Class used for storing data related a single museum.
    /// </summary>
    class Location : Location
    {
        public string Type { get; set; }
        public List<Weekday> Workdays { get; set; }
        public double Price { get; set; }
        public bool HasGuide { get; set; }

        public Location(string name, string city, string address, int year, string manager, string type, List<Weekday> workdays, double price, bool hasGuide) : base(name, city, address, year, manager)
        {
            Type = type;
            Workdays = workdays;
            Price = price;
            HasGuide = hasGuide;
        }
    }
}
