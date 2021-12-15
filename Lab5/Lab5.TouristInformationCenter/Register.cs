using System;
using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    /// <summary>
    /// Class used to store multiple locations in one place
    /// </summary>
    class Register
    {
        private LocationsContainer AllLocations;

        public Register()
        {
            AllLocations = new LocationsContainer();
        }

        public Register(LocationsContainer locations)
        {
            AllLocations = new LocationsContainer(locations);
        }

        /// <summary>
        /// Add one location to the register.
        /// </summary>
        /// <param name="location">Target location</param>
        public void Add(Location location)
        {
            AllLocations.Add(location);
        }

        /// <summary>
        /// The amount of stored locations in the register.
        /// </summary>
        /// <returns>Location count</returns>
        public int Count()
        {
            return AllLocations.Count;
        }

        /// <summary>
        /// Access location from register by index
        /// </summary>
        /// <param name="index">Target index</param>
        /// <returns>Location</returns>
        public Location GetByIndex(int index)
        {
            return AllLocations.Get(index);
        }

        public int CountLocationsThatHaveGuides()
        {
            int count = 0;
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Museum museum = AllLocations.Get(i) as Museum;
                if (museum != null && museum.HasGuide)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Get all of the different types of cities.
        /// </summary>
        /// <returns>A list of city names</returns>
        public List<string> GetAllCities()
        {
            List<string> cities = new List<string>();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Location location = AllLocations.Get(i);
                if (!cities.Contains(location.City))
                {
                    cities.Add(location.City);
                }
            }
            return cities;
        }

        public List<string> GetAllTypes()
        {
            List<string> types = new List<string>();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Museum museum = AllLocations.Get(i) as Museum;
                if (museum != null && !types.Contains(museum.Type))
                {
                    types.Add(museum.Type);
                }
            }
            return types;
        }

        public List<string> FindCommonTypesBetweenCities()
        {
            List<string> allCities = GetAllCities();
            Dictionary<string, int> types = new Dictionary<string, int>();
            foreach (string type in GetAllTypes())
            {
                types.Add(type, 0);
                foreach (string city in allCities)
                {
                    for (int i = 0; i < AllLocations.Count; i++)
                    {
                        Museum museum = AllLocations.Get(i) as Museum;
                        if (museum != null && museum.Type == type && museum.City == city)
                        {
                            types[type]++;
                            break;
                        }
                    }
                }
            }

            List<string> result = new List<string>();
            foreach (var item in types)
            {
                if (item.Value == allCities.Count)
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }

        public bool HasGuideAtWeekendByType(string type)
        {
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Museum museum = AllLocations.Get(i) as Museum;
                if (museum != null && museum.Type == type && museum.HasGuide && (museum.Workdays.Contains(Weekday.Saturday) || museum.Workdays.Contains(Weekday.Sunday)))
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> FindCommonTypesWithGuidesAtWeekends()
        {
            List<string> types = new List<string>();
            foreach (string type in FindCommonTypesBetweenCities())
            {
                if (HasGuideAtWeekendByType(type))
                {
                    types.Add(type);
                }
            }
            return types;
        }

        public LocationsContainer FindLocationsByAuthor(string author)
        {
            LocationsContainer locations = new LocationsContainer();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Statue statue = AllLocations.Get(i) as Statue;
                if (statue != null && statue.Author == author)
                {
                    locations.Add(statue);
                }
            }
            return locations;
        }

        public LocationsContainer FindLocationsAfterYear(int year)
        {
            LocationsContainer locations = new LocationsContainer();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Location location = AllLocations.Get(i);
                if (location.Year > year)
                {
                    locations.Add(location);
                }
            }
            return locations;
        }
    }
}
