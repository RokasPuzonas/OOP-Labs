using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Exercises.Register
{
    class DogsRegister
    {
        private DogsContainer AllDogs;
        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }
        public DogsRegister(DogsContainer Dogs)
        {
            AllDogs = new DogsContainer();
            for (int i = 0; i < Dogs.Count; i++)
            {
                this.AllDogs.Add(Dogs.Get(i));
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
            return AllDogs.Get(index);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
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

        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(DogsContainer Dogs)
        {
            Dog oldest = Dogs.Get(0);
            for (int i = 1; i < Dogs.Count; i++) //starts on index value 1
            {
                Dog dog = Dogs.Get(i);
                if (DateTime.Compare(oldest.BirthDate, dog.BirthDate) > 0)
                {
                    oldest = dog;
                }
            }
            return oldest;
        }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
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

        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                Dog dog = AllDogs.Get(i);
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
