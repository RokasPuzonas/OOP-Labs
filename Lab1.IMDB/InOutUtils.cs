using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab1.IMDB
{
	class InOutUtils
	{
		public static List<Movie> ReadMovies(string filename)
		{
			List<Movie> movies = new List<Movie>();
			string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
			foreach (string line in lines)
			{
				string[] values = line.Split(';');
				string title = values[0];
				int year = int.Parse(values[1]);
				string genre = values[2];
				string studio = values[3];
				string producer = values[4];
				string actor1 = values[5];
				string actor2 = values[6];
				Movie movie = new Movie(title, year, genre, studio, producer, actor1, actor2);
				movies.Add(movie);
			}
			return movies;
		}

		public static void WriteActors(string filename, List<string> actors)
		{
			string[] lines = new string[actors.Count];
			for (int i = 0; i < actors.Count; i++)
			{
				lines[i] = actors[i];
			}
			File.WriteAllLines(filename, lines, Encoding.UTF8);
		}
	}
}
