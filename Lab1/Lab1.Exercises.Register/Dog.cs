using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises.Register
{
    class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            ID = id;
            Name = name;
            Breed = breed;
            BirthDate = birthDate;
            Gender = gender;
        }
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
