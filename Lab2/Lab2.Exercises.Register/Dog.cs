using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Register
{
    class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastVaccinationDate { get; set; }

        private const int VaccinationDuration = 1;

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
            }
        }


        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            ID = id;
            Name = name;
            Breed = breed;
            BirthDate = birthDate;
            Gender = gender;
        }

        public override bool Equals(object other)
        {
            return ID == ((Dog)other).ID;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
