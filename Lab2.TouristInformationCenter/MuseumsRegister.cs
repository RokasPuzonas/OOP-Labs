using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.TouristInformationCenter
{
    /// <summary>
    /// Class used to store multiple museums in one place
    /// </summary>
    class MuseumsRegister
    {
        private List<Museum> AllMuseums;

				public int size = 100;

        public MuseumsRegister()
        {
            AllMuseums = new List<Museum>();
        }

        public MuseumsRegister(List<Museum> museums)
        {
            AllMuseums = new List<Museum>();
            foreach (Museum museum in museums)
            {
                Add(museum);
            }
        }

        /// <summary>
        /// Add one museum to the register.
        /// </summary>
        /// <param name="museum">Target museum</param>
        public void Add(Museum museum)
        {
            this.AllMuseums.Add(museum);
        }

        /// <summary>
        /// The amount of stored museums in the register.
        /// </summary>
        /// <returns>Museum count</returns>
        public int Count()
        {
            return AllMuseums.Count;
        }

        /// <summary>
        /// Access museum from register by index
        /// </summary>
        /// <param name="index">Target index</param>
        /// <returns>Museum</returns>
        public Museum GetByIndex(int index)
        {
            return AllMuseums[index];
        }

        /// <summary>
        /// Return a list of active museums from the register.
        /// A museum is considered active if it is working at least some amount a week.
        /// </summary>
        /// <param name="threshold">Threshold which determines what is active</param>
        /// <returns>A list of active museums</returns>
        public List<Museum> FilterByActiveMuseums(int threshold)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in AllMuseums)
            {
                if (museum.Workdays.Count >= threshold)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Find museum that work the most days in a week
        /// </summary>
        /// <returns>Most active museum</returns>
        private static Museum FindMostActiveMuseum()
        {
            if (AllMuseums.Count == 0)
            {
                return null;
            }

            Museum mostActive = AllMuseums[0];
            foreach (Museum museum in AllMuseums)
            {
                if (museum.Workdays.Count > mostActive.Workdays.Count)
                {
                    mostActive = museum;
                }
            }
            return mostActive;
        }

        /// <summary>
        /// Find all museums that work the most days in a week
        /// </summary>
        /// <returns></returns>
        public List<Museum> FindMostActiveMuseums()
        {
            Museum mostActive = FindMostActiveMuseum();
            List<Museum> activeMuseums = new List<Museum>();
            foreach (Museum museum in AllMuseums)
            {
                if (museum.Workdays.Count == mostActive.Workdays.Count)
                {
                    activeMuseums.Add(museum);
                }
            }
            return activeMuseums;
        }
        
        /// <summary>
        /// Get all of the different types of cities.
        /// </summary>
        /// <returns>A list of city names</returns>
        public List<string> GetAllCities()
        {
            List<string> cities = new List<string>();
            foreach (Museum museum in AllMuseums)
            {
                if (!cities.Contains(museum.City))
                {
                    cities.Add(museum.City);
                }
            }
            return cities;
        }

        /// <summary>
        /// Get the number of museums that a certain city has.
        /// </summary>
        /// <param name="city">Target city</param>
        /// <returns>Museum count by target city</returns>
        public int GetCountByCity(string city)
        {
            int count = 0;
            foreach (Museum museum in AllMuseums)
            {
                if (museum.City == city)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Filter the museums by city name from register
        /// </summary>
        /// <param name="city">Target city</param>
        /// <returns>A list of museums</returns>
        public List<Museum> FilterByCity(string city)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in AllMuseums)
            {
                if (museum.City == city)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Count the number of museums that have a guide from given list
        /// </summary>
        /// <param name="museums">A list of museums</param>
        /// <returns>Museum count that have guides</returns>
        public static int CountByGuide(List<Museum> museums)
        {
            int count = 0;
            foreach (Museum museum in museums)
            {
                if (museum.HasGuide)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Find city which has the most guides from the register
        /// </summary>
        /// <returns>City with the most guides</returns>
        public string FindCityWithMostGuides()
        {
            List<string> cities = GetAllCities();
            if (cities.Count == 0)
            {
                return null;
            }

            string mostPopular = cities[0];
            int mostPopularCount = CountByGuide(FilterByCity(cities[0]));
            for (int i = 1; i < cities.Count; i++)
            {
                string city = cities[i];
                int count = CountByGuide(FilterByCity(city));
                if (count > mostPopularCount)
                {
                    mostPopular = city;
                    mostPopularCount = count;
                }
            }

            return mostPopular;
        }

        /// <summary>
        /// Filter given museums by property "Type".
        /// </summary>
        /// <param name="museums">List of museums</param>
        /// <param name="type">Target type</param>
        /// <returns>A filtered list of museums</returns>
        public static List<Museum> FilterByType(List<Museum> museums, string type)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in museums)
            {
                if (museum.Type == type)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }
    }
}
