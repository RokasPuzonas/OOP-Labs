using System.Collections.Generic;

namespace Lab5.TouristInformationCenter
{
    class LocationsContainer
    {
        private Location[] locations;
        private int Capacity;
        public int Count { get; private set; }
        public LocationsContainer(int capacity = 16)
        {
            Capacity = capacity;
            locations = new Location[capacity];
        }

        public LocationsContainer(LocationsContainer container) : this(container.Capacity)
        {
            for (int i = 0; i < container.Count; i++)
            {
                Add(container.Get(i));
            }
        }

        /// <summary>
        /// Add a location to the end of the container
        /// </summary>
        /// <param name="location">Target location</param>
        public void Add(Location location)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            locations[Count] = location;
            Count++;
        }

        /// <summary>
        /// Get a musem by index from container
        /// </summary>
        /// <param name="index">Target index</param>
        /// <returns>Location at given index</returns>
        public Location Get(int index)
        {
            return locations[index];
        }

        /// <summary>
        /// Check if given location exists in container
        /// </summary>
        /// <param name="location">Target location</param>
        /// <returns>True if contains</returns>
        public bool Contains(Location location)
        {
            for (int i = 0; i < Count; i++)
            {
                if (locations[i].Equals(location))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Put a location at a specific index
        /// </summary>
        /// <param name="index">Target index</param>
        /// <param name="location">Target location</param>
        public void Put(int index, Location location)
        {
            locations[index] = location;
        }

        /*

        /// <summary>
        /// Filter by property "HasGuide"
        /// </summary>
        /// <param name="hasGuide">Target value</param>
        /// <returns>A filtered container of locations</returns>
        public LocationsContainer FilterByGuide(bool hasGuide)
        {
            LocationsContainer filtered = new LocationsContainer();
            for (int i = 0; i < Count; i++)
            {
                Location location = locations[i];
                if (location.HasGuide == hasGuide)
                {
                    filtered.Add(location);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Type".
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>A filtered container of locations</returns>
        public LocationsContainer FilterByType(string type)
        {
            LocationsContainer filtered = new LocationsContainer();
            for (int i = 0; i < Count; i++)
            {
                Location location = locations[i];
                if (location.Type == type)
                {
                    filtered.Add(location);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Price".
        /// </summary>
        /// <param name="maxPrice">Maximum allowed price to be included</param>
        /// <returns>A container with locations that dont't have a larger price then "maxPrice"</returns>
        public LocationsContainer FilterByPrice(double maxPrice)
        {
            LocationsContainer filtered = new LocationsContainer();
            for (int i = 0; i < Count; i++)
            {
                Location location = locations[i];
                if (location.Price <= maxPrice)
                {
                    filtered.Add(location);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Return a list of "active" locations from the contaner.
        /// A location is considered active if it is working at least some amount a week.
        /// </summary>
        /// <param name="threshold">Threshold which determines what is active</param>
        /// <returns>A container of "active" locations</returns>
        public LocationsContainer FilterByActivity(int threshold)
        {
            LocationsContainer filtered = new LocationsContainer();
            for (int i = 0; i < Count; i++)
            {
                Location location = locations[i];
                if (location.Workdays.Count >= threshold)
                {
                    filtered.Add(location);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Name"
        /// </summary>
        /// <param name="name">Target name</param>
        /// <returns>A filtered container</returns>
        public LocationsContainer FilterByName(string name)
        {
            LocationsContainer filtered = new LocationsContainer();
            for (int i = 0; i < Count; i++)
            {
                Location location = locations[i];
                if (location.Name == name)
                {
                    filtered.Add(location);
                }
            }
            return filtered;
        }
        */

        /// <summary>
        /// Sort container by given comparator
        /// </summary>
        /// <param name="comparator">Defined how it should be sorted</param>
        public void Sort(LocationsComparator comparator)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    Location a = locations[i];
                    Location b = locations[j];
                    if (comparator.Compare(a, b) > 0)
                    {
                        locations[i] = b;
                        locations[j] = a;
                    }
                }
            }
        }

        /// <summary>
        /// Sort container by "Name" in alphabetical order.
        /// </summary>
        public void Sort()
        {
            Sort(new LocationsComparator());
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity <= Capacity) return;

            Location[] locationsClone = new Location[minimumCapacity];
            for (int i = 0; i < Count; i++)
            {
                locationsClone[i] = locations[i];
            }
            Capacity = minimumCapacity;
            locations = locationsClone;
        }
    }
}
