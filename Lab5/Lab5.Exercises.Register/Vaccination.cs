using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class Vaccination
    {
        public int AnimalID { get; set; }
        public DateTime Date { get; set; }
        public Vaccination(int animalID, DateTime date)
        {
            AnimalID = animalID;
            Date = date;
        }
        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }
        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }

    }
}
