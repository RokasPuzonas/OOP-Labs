using System.Collections.Generic;

namespace Lab1.TouristInformationCenter
{
    /// <summary>
    /// Class used for storing functions that manipulate or filter data.
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Return a sub-list of given museums where all museums in the returned list are free and have a guide.
        /// </summary>
        /// <param name="museums">List of museums</param>
        /// <returns>Filtered sub-list of museums</returns>
        public static List<Museum> FilterByFreeAndWithGuide(List<Museum> museums)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in museums)
            {
                if (museum.HasGuide && museum.Price == 0)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Return a sub-list of given museums where all museums in the returned list are "active".
        /// A museum is considered active if it is working at least 5 times a week.
        /// </summary>
        /// <param name="museums">List of museums</param>
        /// <returns>Filtered sub-list of museums</returns>
        public static List<Museum> FilterByActiveMuseums(List<Museum> museums)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in museums)
            {
                if (museum.Workdays.Count >= 5)
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Return a sub-list of given museums where all museums in the returned list are from "non-popular" cities.
        /// A city is "non-popular" if it is not "Vilnius", "Kaunas" or "Klaipėda".
        /// </summary>
        /// <param name="museums">List of museums</param>
        /// <returns>Filtered sub-list of museums</returns>
        public static List<Museum> FilterByNonPopularCity(List<Museum> museums)
        {
            List<Museum> filtered = new List<Museum>();
            foreach (Museum museum in museums)
            {
                if (!(museum.City.Equals("Vilnius") || museum.City.Equals("Kaunas") || museum.City.Equals("Klaipėda")))
                {
                    filtered.Add(museum);
                }
            }
            return filtered;
        }
    }
}
