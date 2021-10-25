using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.TouristInformationCenter
{
    class MuseumsContainer
    {
        private Museum[] museums;
        private int Capacity;
        public int Count { get; private set; }
        public MuseumsContainer(int capacity = 16)
        {
            Capacity = capacity;
            museums = new Museum[capacity];
        }

        public MuseumsContainer(MuseumsContainer container) : this(container.Capacity)
        {
            for (int i = 0; i < container.Count; i++)
            {
                Add(container.Get(i));
            }
        }

        /// <summary>
        /// Add a museum to the end of the container
        /// </summary>
        /// <param name="museum">Target museum</param>
        public void Add(Museum museum)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            museums[Count] = museum;
            Count++;
        }

        /// <summary>
        /// Get a musem by index from container
        /// </summary>
        /// <param name="index">Target index</param>
        /// <returns>Museum at given index</returns>
        public Museum Get(int index)
        {
            return museums[index];
        }

        /// <summary>
        /// Check if given museum exists in container
        /// </summary>
        /// <param name="museum">Target museum</param>
        /// <returns>True if contains</returns>
        public bool Contains(Museum museum)
        {
            for (int i = 0; i < Count; i++)
            {
                if (museums[i].Equals(museum))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Put a museum at a specific index
        /// </summary>
        /// <param name="index">Target index</param>
        /// <param name="museum">Target museum</param>
        public void Put(int index, Museum museum)
        {
            museums[index] = museum;
        }

        /// <summary>
        /// Filter by property "HasGuide"
        /// </summary>
        /// <param name="hasGuide">Target value</param>
        /// <returns>A filtered container of museums</returns>
        public MuseumsContainer FilterByGuide(bool hasGuide)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.HasGuide == hasGuide)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Type".
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>A filtered container of museums</returns>
        public MuseumsContainer FilterByType(string type)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.Type == type)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Price".
        /// </summary>
        /// <param name="maxPrice">Maximum allowed price to be included</param>
        /// <returns>A container with museums that dont't have a larger price then "maxPrice"</returns>
        public MuseumsContainer FilterByPrice(double maxPrice)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.Price <= maxPrice)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Type"
        /// </summary>
        /// <param name="city">Target city</param>
        /// <returns>A container of museums</returns>
        public MuseumsContainer FilterByCity(string city)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.City == city)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Return a list of "active" museums from the contaner.
        /// A museum is considered active if it is working at least some amount a week.
        /// </summary>
        /// <param name="threshold">Threshold which determines what is active</param>
        /// <returns>A container of "active" museums</returns>
        public MuseumsContainer FilterByActivity(int threshold)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.Workdays.Count >= threshold)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter by property "Name"
        /// </summary>
        /// <param name="name">Target name</param>
        /// <returns>A filtered container</returns>
        public MuseumsContainer FilterByName(string name)
        {
            MuseumsContainer filtered = new MuseumsContainer();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (museum.Name == name)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Get all of the different types of cities.
        /// </summary>
        /// <returns>A list of city names</returns>
        public List<string> GetAllCities()
        {
            List<string> cities = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                Museum museum = museums[i];
                if (!cities.Contains(museum.City))
                {
                    cities.Add(museum.City);
                }
            }
            return cities;
        }

        /// <summary>
        /// Sort container by "City" and "Name" in alphabetical order.
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    Museum a = museums[i];
                    Museum b = museums[j];
                    int nameCompare = a.Name.CompareTo(b.Name);
                    int cityCompare = a.City.CompareTo(b.City);
                    if (cityCompare > 0 || (cityCompare == 0 && nameCompare > 0))
                    {
                        museums[i] = b;
                        museums[j] = a;
                    }
                }
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity <= Capacity) return;

            Museum[] museumsClone = new Museum[minimumCapacity];
            for (int i = 0; i < Count; i++)
            {
                museumsClone[i] = museums[i];
            }
            Capacity = minimumCapacity;
            museums = museumsClone;
        }
    }
}
