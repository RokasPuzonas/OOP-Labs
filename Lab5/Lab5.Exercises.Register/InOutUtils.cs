using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab5.Exercises.Register
{
    class InOutUtils
    {
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] values = line.Split(';');
                int id = int.Parse(values[0]);
                DateTime vaccinationDate = DateTime.Parse(values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }

        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);
                Gender gender;
                Enum.TryParse(values[5], out gender); //tries to convert value to enum
                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    default:
                        break;//unknown type
                }
            }
            return animals;
        }

        public static void PrintAnimals(Register register)
        {
            PrintAnimalsHeader();
            for (int i = 0; i < register.AnimalsCount(); i++)
            {
                PrintAnimalsRow(register.GetByIndex(i));
            }
            PrintAnimalsFooter();
        }

        public static void PrintAnimals(List<Animal> animals)
        {
            PrintAnimalsHeader();
            foreach (Animal animal in animals)
            {
                PrintAnimalsRow(animal);
            }
            PrintAnimalsFooter();
        }

        public static void PrintAnimals(AnimalsContainer container)
        {
            PrintAnimalsHeader();
            for (int i = 0; i < container.Count; i++)
            {
                PrintAnimalsRow(container.Get(i));
            }
            PrintAnimalsFooter();
        }

        public static void PrintAnimals(string label, AnimalsContainer container)
        {
            PrintAnimalsHeader(label);
            for (int i = 0; i < container.Count; i++)
            {
                PrintAnimalsRow(container.Get(i));
            }
            PrintAnimalsFooter();
        }

        private static void PrintAnimalsHeader()
        {
            Console.WriteLine(new string('-', 87));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,-10} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agresyvus");
            Console.WriteLine(new string('-', 87));
        }

        private static void PrintAnimalsHeader(string label)
        {
            Console.WriteLine(new string('-', 87));
            Console.WriteLine("| {0,-70} |", label);
            PrintAnimalsHeader();
        }

        private static void PrintAnimalsFooter()
        {
            Console.WriteLine(new string('-', 87));
        }

        private static void PrintAnimalsRow(Animal animal)
        {
            if (animal is Dog)
            {
                Dog dog = animal as Dog;
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-10} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender, dog.Aggresive ? "taip" : "ne");
            } else
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5, -10} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender, "-");
            }
        }


        public static void PrintAnimal(Animal animal)
        {
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", animal.Name, animal.Breed, animal.Age);
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, List<Animal> Animals)
        {
            string[] lines = new string[Animals.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Animals.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", Animals[i].ID, Animals[i].Name, Animals[i].Breed, Animals[i].BirthDate, Animals[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
