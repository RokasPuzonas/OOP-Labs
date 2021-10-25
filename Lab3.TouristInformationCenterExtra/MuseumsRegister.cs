using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.TouristInformationCenterExtra
{
    /// <summary>
    /// Class used to store multiple museums in one place
    /// </summary>
    class MuseumsRegister
    {
        private MuseumsContainer AllMuseums;

        public MuseumsRegister()
        {
            AllMuseums = new MuseumsContainer();
        }

        public MuseumsRegister(MuseumsContainer museums)
        {
            AllMuseums = new MuseumsContainer(museums);
        }

        /// <summary>
        /// Add one museum to the register.
        /// </summary>
        /// <param name="museum">Target museum</param>
        public void Add(Museum museum)
        {
            AllMuseums.Add(museum);
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
            return AllMuseums.Get(index);
        }

        /// <summary>
        /// Return a list of active museums from the register.
        /// A museum is considered active if it is working at least some amount a week.
        /// </summary>
        /// <param name="threshold">Threshold which determines what is active</param>
        /// <returns>A list of active museums</returns>
        public MuseumsContainer FilterByActiveMuseums(int threshold)
        {
            return AllMuseums.FilterByActivity(threshold);
        }

        /// <summary>
        /// Find museum that work the most days in a week
        /// </summary>
        /// <returns>Most active museum</returns>
        public Museum FindMostActiveMuseum()
        {
            if (AllMuseums.Count == 0)
            {
                return null;
            }

            Museum mostActive = AllMuseums.Get(0);
            for (int i = 0; i < AllMuseums.Count; i++)
            {
                Museum museum = AllMuseums.Get(i);
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
        public MuseumsContainer FindMostActiveMuseums()
        {
            Museum mostActive = FindMostActiveMuseum();
            MuseumsContainer activeMuseums = new MuseumsContainer();
            for (int i = 0; i < AllMuseums.Count; i++)
            {
                Museum museum = AllMuseums.Get(i);
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
            return AllMuseums.GetAllCities();
        }

        /// <summary>
        /// Filter the museums by city name from register
        /// </summary>
        /// <param name="city">Target city</param>
        /// <returns>A container of museums</returns>
        public MuseumsContainer FilterByCity(string city)
        {
            return AllMuseums.FilterByCity(city);
        }

        /// <summary>
        /// Filter by property "Type".
        /// </summary>
        /// <param name="type">Target type</param>
        /// <returns>A filtered container of museums</returns>
        public MuseumsContainer FilterByType(string type)
        {
            return AllMuseums.FilterByType(type);
        }

        private List<string> GetMuseumNames()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < AllMuseums.Count; i++)
            {
                Museum museum = AllMuseums.Get(i);
                if (!result.Contains(museum.Name))
                {
                    result.Add(museum.Name);
                }
            }
            return result;
        }

        public MuseumsContainer FindMuseumsWithDuplicateNames()
        {
            MuseumsContainer result = new MuseumsContainer();
            List<string> names = GetMuseumNames();
            foreach (string name in names)
            {
                MuseumsContainer museumsByName = AllMuseums.FilterByName(name);
                if (museumsByName.Count <= 1) continue;
                
                for (int i = 0; i < museumsByName.Count; i++)
                {
                    result.Add(museumsByName.Get(i));
                }
            }
            return result;
        }

    }
}
