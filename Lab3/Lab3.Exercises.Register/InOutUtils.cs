﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab3.Exercises.Register
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

        public static DogsContainer ReadDogs(string fileName)
        {
            DogsContainer Dogs = new DogsContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                int id = int.Parse(values[0]);
                string name = values[1];
                string breed = values[2];
                DateTime birthDate = DateTime.Parse(values[3]);
                Gender gender;
                Enum.TryParse(values[4], out gender); //tries to convert value to enum
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
        }
        public static void PrintDogs(DogsRegister register)
        {
            PrintDogsHeader();
            for (int i = 0; i < register.DogsCount(); i++)
            {
                Dog dog = register.GetByIndex(i);
                PrintDogsRow(register.GetByIndex(i));
            }
            PrintDogsFooter();
        }

        public static void PrintDogs(List<Dog> dogs)
        {
            PrintDogsHeader();
            foreach (Dog dog in dogs)
            {
                PrintDogsRow(dog);
            }
            PrintDogsFooter();
        }

        public static void PrintDogs(DogsContainer container)
        {
            PrintDogsHeader();
            for (int i = 0; i < container.Count; i++)
            {
                Dog dog = container.Get(i);
                PrintDogsRow(dog);
            }
            PrintDogsFooter();
        }

        public static void PrintDogs(string label, DogsContainer container)
        {
            PrintDogsHeader(label);
            for (int i = 0; i < container.Count; i++)
            {
                Dog dog = container.Get(i);
                PrintDogsRow(dog);
            }
            PrintDogsFooter();
        }

        private static void PrintDogsHeader()
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
        }

        private static void PrintDogsHeader(string label)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
        }

        private static void PrintDogsFooter()
        {
            Console.WriteLine(new string('-', 74));
        }

        private static void PrintDogsRow(Dog dog)
        {
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
        }


        public static void PrintDog(Dog dog)
        {
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", dog.Name, dog.Breed, dog.Age);
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
