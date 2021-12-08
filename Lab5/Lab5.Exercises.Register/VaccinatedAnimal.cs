using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    abstract class VaccinatedAnimal : Animal
    {
        public DateTime LastVaccinationDate { get; set; }
        public abstract bool RequiresVaccination { get; }

        public VaccinatedAnimal(int id, string name, string breed, DateTime birthDate, Gender gender) : base(id, name, breed, birthDate, gender)
        {
        }
    }
}
