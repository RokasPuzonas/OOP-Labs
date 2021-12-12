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
                Location museum = AllLocations.Get(i) as Location;
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
                Location museum = AllLocations.Get(i) as Location;
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
                        Location museum = AllLocations.Get(i) as Location;
                        if (museum != null && museum.Type == type && museum.City == city)
                        {
                            types[type]++;
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
                if (museum != null && museum.Type == type && museum.HasGuide)
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

        /*
        /// <summary>
        /// Return a list of active locations from the register.
        /// A location is considered active if it is working at least some amount a week.
        /// </summary>
        /// <param name="threshold">Threshold which determines what is active</param>
        /// <returns>A list of active locations</returns>
        public LocationsContainer FilterByActiveLocations(int threshold)
        {
            return AllLocations.FilterByActivity(threshold);
        }

        /// <summary>
        /// Find location that work the most days in a week
        /// </summary>
        /// <returns>Most active location</returns>
        public Location FindMostActiveLocation()
        {
            if (AllLocations.Count == 0)
            {
                return null;
            }

            Location mostActive = AllLocations.Get(0);
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Location location = AllLocations.Get(i);
                if (location.Workdays.Count > mostActive.Workdays.Count)
                {
                    mostActive = location;
                }
            }
            return mostActive;
        }

        /// <summary>
        /// Find all locations that work the most days in a week
        /// </summary>
        /// <returns></returns>
        public LocationsContainer FindMostActiveLocations()
        {
            Location mostActive = FindMostActiveLocation();
            LocationsContainer activeLocations = new LocationsContainer();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Location location = AllLocations.Get(i);
                if (location.Workdays.Count == mostActive.Workdays.Count)
                {
                    activeLocations.Add(location);
                }
            }
            return activeLocations;
        }

        /// <summary>
        /// Filter by property "Type".
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>A filtered container of locations</returns>
        public LocationsContainer FilterByType(string type)
        {
            return AllLocations.FilterByType(type);
        }

        private List<string> GetLocationNames()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < AllLocations.Count; i++)
            {
                Location location = AllLocations.Get(i);
                if (!result.Contains(location.Name))
                {
                    result.Add(location.Name);
                }
            }
            return result;
        }

        /// <summary>
        /// Find all locations that have matching names
        /// </summary>
        /// <returns>A container with locations that have matching names</returns>
        public LocationsContainer FindLocationsWithDuplicateNames()
        {
            LocationsContainer result = new LocationsContainer();
            List<string> names = GetLocationNames();
            foreach (string name in names)
            {
                LocationsContainer locationsByName = AllLocations.FilterByName(name);
                if (locationsByName.Count <= 1) continue;

                for (int i = 0; i < locationsByName.Count; i++)
                {
                    result.Add(locationsByName.Get(i));
                }
            }
            return result;
        }
        */

    }
}
