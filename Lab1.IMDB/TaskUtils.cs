using System.Collections.Generic;
using System;

namespace Lab1.IMDB
{
	class TaskUtils
	{
		public static List<Movie> FilterByActors(List<Movie> movies, string actor1, string actor2)
		{
			List<Movie> filtered = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.Actor1 == actor1 && movie.Actor2 == actor2 || movie.Actor1 == actor2 && movie.Actor2 == actor1)
				{
					filtered.Add(movie);
				}
			}
			return filtered;
		}

		public static List<Movie> FilterByStudio(List<Movie> movies, string studio)
		{
			List<Movie> filtered = new List<Movie>();
			foreach (Movie movie in movies)
			{
				if (movie.Studio.Equals(studio))
				{
					filtered.Add(movie);
				}
			}
			return filtered;
		}

		public static List<string> GetActors(List<Movie> movies)
		{
			List<string> actors = new List<string>();
			foreach (Movie movie in movies)
			{
				if (!actors.Contains(movie.Actor1))
				{
					actors.Add(movie.Actor1);
				}
				if (!actors.Contains(movie.Actor2))
				{
					actors.Add(movie.Actor2);
				}
			}
			return actors;
		}
	}
}
