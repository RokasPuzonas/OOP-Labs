using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Register
{
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }

        public int DogsCount()
        {
            return AllDogs.Count;
        }

        public Dog GetByIndex(int index)
        {
            return AllDogs[index];
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 1; i < Dogs.Count; i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;

        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = FindDogByID(vaccination.DogID);
                if (dog != null && vaccination > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vaccination.Date;
                }
            }
        }

        public List<Dog> FilterByVaccinationExpired()
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in AllDogs)
            {
                if (dog.RequiresVaccination)
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
