using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class Register
    {
        private AnimalsContainer AllAnimals;
        public Register()
        {
            AllAnimals = new AnimalsContainer();
        }
        public Register(AnimalsContainer Animals)
        {
            AllAnimals = new AnimalsContainer();
            for (int i = 0; i < Animals.Count; i++)
            {
                this.AllAnimals.Add(Animals.Get(i));
            }
        }
        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
        }

        public int AnimalsCount()
        {
            return AllAnimals.Count;
        }

        public Animal GetByIndex(int index)
        {
            return AllAnimals.Get(index);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal animal = AllAnimals.Get(i);
                if (animal.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this.AllAnimals);
        }

        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal animal = AllAnimals.Get(i);
                if (animal.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }

        public Animal FindOldestAnimal(string breed)
        {
            AnimalsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestAnimal(Filtered);
        }
        private Animal FindOldestAnimal(AnimalsContainer Animals)
        {
            Animal oldest = Animals.Get(0);
            for (int i = 1; i < Animals.Count; i++) //starts on index value 1
            {
                Animal animal = Animals.Get(i);
                if (DateTime.Compare(oldest.BirthDate, animal.BirthDate) > 0)
                {
                    oldest = animal;
                }
            }
            return oldest;
        }
        private Animal FindAnimalByID(int ID)
        {
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                Animal animal = AllAnimals.Get(i);
                if (animal.ID == ID)
                {
                    return animal;
                }
            }
            return null;

        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                VaccinatedAnimal animal = FindAnimalByID(vaccination.AnimalID) as VaccinatedAnimal;
                if (animal != null && vaccination > animal.LastVaccinationDate)
                {
                    animal.LastVaccinationDate = vaccination.Date;
                }
            }
        }

        public AnimalsContainer FilterByVaccinationExpired()
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                VaccinatedAnimal animal = AllAnimals.Get(i) as VaccinatedAnimal;
                if (animal != null && animal.RequiresVaccination)
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }
        public bool Contains(Animal animal)
        {
            return AllAnimals.Contains(animal);
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
