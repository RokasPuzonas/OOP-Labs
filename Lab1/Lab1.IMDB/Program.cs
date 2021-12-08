using System;
using System.Collections.Generic;

// Variant U1-21.
namespace Lab1.IMDB
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Movie> movies = InOutUtils.ReadMovies("Movies.csv");

			List<Movie> filteredByActors = TaskUtils.FilterByActors(movies, "T. Cruise", "N. Kidman");
			Console.WriteLine("Movies with T. Cruise and N. Kidman:");
			foreach (Movie movie in filteredByActors)
			{
				Console.WriteLine("{0} {1}", movie.Title, movie.Year);
			}
			Console.WriteLine();


			List<Movie> filteredByStudio = TaskUtils.FilterByStudio(movies, "Warner Bros");
			Console.WriteLine("Movies by Warner Bros:");
			foreach (Movie movie in filteredByStudio)
			{
				Console.WriteLine("{0} {1}", movie.Title, movie.Year);
			}

			List<string> actors = TaskUtils.GetActors(movies);
			InOutUtils.WriteActors("Actors.csv", actors);
		}
	}
}
