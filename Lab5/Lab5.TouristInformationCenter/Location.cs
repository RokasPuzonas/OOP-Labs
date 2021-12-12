
namespace Lab5.TouristInformationCenter
{
    abstract class Location
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public string Manager { get; set; }

        public Location(string name, string city, string address, int year, string manager)
        {
            Name = name;
            City = city;
            Address = address;
            Year = year;
            Manager = manager;
        }

        public int CompareTo(Location other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
