using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    /// <summary>
    /// Class used for storing data related a single museum.
    /// </summary>
    class Museum : Location
    {
        public string Type { get; set; }
        public List<Weekday> Workdays { get; set; }
        public double Price { get; set; }
        public bool HasGuide { get; set; }

        public Museum(string city, string manager, string name, string address, int year, string type, List<Weekday> workdays, double price, bool hasGuide) : base(city, manager, name, address, year)
        {
            Type = type;
            Workdays = workdays;
            Price = price;
            HasGuide = hasGuide;
        }
    }
}
