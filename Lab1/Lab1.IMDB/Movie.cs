
namespace Lab1.IMDB
{
    class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Studio { get; set; }
        public string Producer { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
				public Movie(string title, int year, string genre, string studio, string producer, string actor1, string actor2) {
					Title = title;
					Year = year;
					Genre = genre;
					Studio = studio;
					Producer = producer;
					Actor1 = actor1;
					Actor2 = actor2;
				}
    }
}

