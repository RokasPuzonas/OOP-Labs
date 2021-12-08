using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace Lab3.TouristInformationCenterExtra
{
    class MuseumsContainer
    {
        
        public int Count { get; private set; }
        private static Random random = new Random();
        private string Filename;
        private FileStream fs;

        public MuseumsContainer()
        {
            Filename = ".container"+random.Next(1000).ToString();
            fs = File.Create(Filename);
        }

        public MuseumsContainer(MuseumsContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                Add(container.Get(i));
            }
        }

        ~MuseumsContainer()
        {
            fs.Close();
            //File.Delete(Filename);
        }

        private void SeekToEnd()
        {
            fs.Seek(0, SeekOrigin.End);
        }

        private static Museum DecodeMuseum(string encoded)
        {
            string[] values = encoded.Split(';');
            string name = values[0];
            string city = values[1];
            string manager = values[2];
            string type = values[3];
            List<Weekday> workdays = new List<Weekday>();
            for (int i = 1; i <= 7; i++)
            {
                if (int.Parse(values[i+3]) == 1)
                {
                    workdays.Add((Weekday)i);
                }
            }
            double price = double.Parse(values[11]);
            bool hasGuide = int.Parse(values[12]) == 1;

            return new Museum(name, city, manager, type, workdays, price, hasGuide);
        }

        private static string EncodeMuseum(Museum museum)
        {
            int[] workDays = new int[museum.Workdays.Count];
            for (int i = 0; i < museum.Workdays.Count; i++)
            {
                Weekday day = museum.Workdays[i];
                workDays[i] = Convert.ToInt32(day);
            }

            int hasGuide = Convert.ToInt32(museum.HasGuide);
            string workDaysJoined = String.Join(";", workDays);

            return String.Join(";", museum.Name, museum.City, museum.Manager, museum.Type, workDaysJoined, museum.Price, hasGuide);
        }

        /// <summary>
        /// Add a museum to the end of the container
        /// </summary>
        /// <param name="museum">Target museum</param>
        public void Add(Museum museum)
        {
            SeekToEnd();
            string encoded = EncodeMuseum(museum);
            byte[] bytes = new UTF8Encoding(true).GetBytes(encoded);
            fs.Write(bytes);
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
    }
}
