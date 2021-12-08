﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Register
{
    class Vaccination
    {
        public int DogID { get; set; }
        public DateTime Date { get; set; }
        public Vaccination(int dogID, DateTime date)
        {
            DogID = dogID;
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
