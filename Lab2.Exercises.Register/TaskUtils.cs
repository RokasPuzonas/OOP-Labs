using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Register
{
    class TaskUtils
    {
        public static int CountByGender(List<Dog> dogs, Gender gender)
        {
            int count = 0;
            foreach (Dog dog in dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public static Dog FindOldestDog(List<Dog> dogs)
        {
            Dog oldest = dogs[0]; // means least value
            for (int i = 1; i < dogs.Count; i++)
            {
                if (DateTime.Compare(dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = dogs[i];
                }
            }
            return oldest;
        }
        public static List<string> FindBreeds(List<Dog> dogs)
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public static List<Dog> FilterByBreed(List<Dog> dogs, string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in dogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public static int CountByBreed(List<Dog> dogs, string breed)
        {
            int count = 0;
            foreach (Dog dog in dogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    count++;
                }
            }
            return count;
        }

        public static List<string> FindMostPopularBreeds(List<Dog> dogs)
        {
            List<string> breeds = FindBreeds(dogs);
            int mostPopularCount = CountByBreed(dogs, breeds[0]);
            foreach (string breed in breeds)
            {
                int count = CountByBreed(dogs, breed);
                if (count > mostPopularCount)
                {
                    mostPopularCount = count;
                }
            }

            List<string> popularBreeds = new List<string>();
            foreach (string breed in breeds)
            {
                if (CountByBreed(dogs, breed) == mostPopularCount)
                {
                    popularBreeds.Add(breed);
                }
            }

            return popularBreeds;
        }

    }
}
