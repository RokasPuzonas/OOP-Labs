using System;
using System.Collections.Generic;

namespace Lab3.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog(1, "Foo", "FooBreed", DateTime.Now, Gender.Male);

            Dog dog2 = new Dog(2, "Bar", "BarBreed", DateTime.Now, Gender.Male);

            Dog dog3 = new Dog(3, "Baz", "BazBreed", DateTime.Now, Gender.Female);

            DogsContainer container = new DogsContainer();
            container.Add(dog1);
            container.Add(dog2);
            container.Add(dog3);
            InOutUtils.PrintDogs(container);
            container.Remove(1);
            InOutUtils.PrintDogs(container);

            /*
            DogsContainer container = InOutUtils.ReadDogs("Dogs.csv");
            container.Sort();
            InOutUtils.PrintDogs("Container", container);

            DogsContainer otherContainer = new DogsContainer(container);
            InOutUtils.PrintDogs("Other container", otherContainer);
            */

            /*
            DogsContainer container = InOutUtils.ReadDogs("Dogs.csv");
            DogsRegister register = new DogsRegister(container);
            List<Vaccination> vaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(vaccinationsData);

            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(register);
            Console.WriteLine();
            
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();
            
            Console.WriteLine("Šunys kuriems reikia vakcinuotis:");
            DogsContainer dogsThatNeedVaccination = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogs(dogsThatNeedVaccination);
            Console.WriteLine();

            string vaccinationBreed = "Taksas";
            DogsContainer allDogsByBreed = register.FilterByBreed(vaccinationBreed);
            Console.WriteLine("Šunys kuriems reikia vakcinuotis ({0}):", vaccinationBreed);
            InOutUtils.PrintDogs(allDogsByBreed.Intersect(dogsThatNeedVaccination));
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
