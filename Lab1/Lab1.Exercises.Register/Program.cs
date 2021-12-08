using System;
using System.Collections.Generic;

namespace Lab1.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs("Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);
            Console.WriteLine("Patinų: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Patelių: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();

            Dog oldestDog = TaskUtils.FindOldestDog(allDogs);
            Console.WriteLine("Seniausias šuo:");
            InOutUtils.PrintDog(oldestDog);
            Console.WriteLine();

            List<string> breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(breeds);
            Console.WriteLine();

            List<string> popularBreeds = TaskUtils.FindMostPopularBreeds(allDogs);
            Console.WriteLine("Populiariausios šunų veislės:");
            InOutUtils.PrintBreeds(popularBreeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine().Trim();
            if (selectedBreed.Equals(""))
            {
                Console.WriteLine("Šunio veislė neįvesta");
                return;
            }

            List<Dog> filteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            if (filteredByBreed.Count == 0)
            {
                Console.WriteLine("Šunų su veisle '{0}' nerasta", selectedBreed);
                return;
            }

            Dog oldestFilteredDog = TaskUtils.FindOldestDog(filteredByBreed);
            Console.WriteLine("Seniausias šuo pagal '{0}' veislę:", selectedBreed);
            InOutUtils.PrintDog(oldestFilteredDog);
            InOutUtils.PrintDogs(filteredByBreed);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, filteredByBreed);
            
        }
    }
}
