
namespace Lab5.TouristInformationCenter
{
    class Statue : Location {
        public string Author { get; set; }
        public string MonumentName { get; set; }

        public Statue(string city, string manager, string name, string address, int year, string author, string monumentName) : base(city, manager, name, address, year)
        {
            Author = author;
            MonumentName = monumentName;
        }
    }
}

