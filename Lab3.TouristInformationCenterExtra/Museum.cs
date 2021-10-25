using System.Collections.Generic;

namespace Lab3.TouristInformationCenterExtra
{
    /// <summary>
    /// Class used for storing data related a single museum.
    /// </summary>
    class Museum
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Manager { get; set; }
        public string Type { get; set; }
        public List<Weekday> Workdays { get; set; }
        public double Price { get; set; }
        public bool HasGuide { get; set; }
        public Museum(string name, string city, string manager, string type, List<Weekday> workdays, double price, bool hasGuide)
        {
            Name = name;
            Manager = manager;
            City = city;
            Type = type;
            Workdays = workdays;
            Price = price;
            HasGuide = hasGuide;
        }
    }
}
