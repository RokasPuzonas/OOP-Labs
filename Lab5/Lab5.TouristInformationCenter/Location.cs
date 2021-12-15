
namespace Lab5.TouristInformationCenter
{
    abstract class Location
    {
        public string City { get; set; }
        public string Manager { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }

        public Location(string city, string manager, string name, string address, int year)
        {
            City = city;
            Manager = manager;
            Name = name;
            Address = address;
            Year = year;
        }

        public int CompareTo(Location other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
