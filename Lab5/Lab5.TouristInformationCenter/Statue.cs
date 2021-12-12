
namespace Lab5.TouristInformationCenter
{
    class Statue : Location {
        public string Author { get; set; }
        public string MonumentName { get; set; }

        public Statue(string name, string city, string address, int year, string manager, string author, string monumentName) : base(name, city, address, year, manager)
        {
            Author = author;
            MonumentName = monumentName;
        }
    }
}

