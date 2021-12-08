using System;
using System.Collections.Generic;

namespace Lab5.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {   
            AnimalsContainer container = InOutUtils.ReadAnimals(@"Animals.csv");

            Console.WriteLine("Registro informacija:");
            container.Sort(new AnimalsComparatorByName());
            InOutUtils.PrintAnimals(container);
            Console.WriteLine();

            container.Sort(new AnimalsComparatorByBirthDate());
            InOutUtils.PrintAnimals(container);
            Console.WriteLine();

            /*
            Console.WriteLine("Iš viso gyvūnų: {0}", register.AnimalsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();
            
            Console.WriteLine("Gyvūnai kuriems reikia vakcinuotis:");
            AnimalsContainer animalsThatNeedVaccination = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogs(animalsThatNeedVaccination);
            Console.WriteLine();

            string vaccinationBreed = "Taksas";
            AnimalsContainer allAnimalsByBreed = register.FilterByBreed(vaccinationBreed);
            Console.WriteLine("Gyvūnai kuriems reikia vakcinuotis ({0}):", vaccinationBreed);
            InOutUtils.PrintDogs(allAnimalsByBreed.Intersect(animalsThatNeedVaccination));
            Console.WriteLine();

            Console.WriteLine("Registre yra agresyvių šunų kiekis: {0}", register.CountAggresiveDogs());
            */

            /*
            Dog oldestDog = TaskUtils.FindOldestDog(register);
            Console.WriteLine("Seniausias šuo:");
            InOutUtils.PrintDog(oldestDog);
            Console.WriteLine();

            List<string> breeds = TaskUtils.FindBreeds(register);
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(breeds);
            Console.WriteLine();

            List<string> popularBreeds = TaskUtils.FindMostPopularBreeds(register);
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

            List<Dog> filteredByBreed = TaskUtils.FilterByBreed(register, selectedBreed);
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
            */

        }
    }
}
