using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Savarankiskas4
{
    static class InOutUtils
    {
        public static StudentsContainer ReadStudents(string filename)
        {
            StudentsContainer container = new StudentsContainer();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            string faculty = lines[0].TrimEnd();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(';');
                string surname = values[0];
                string name = values[1];
                string group = values[2];
                int gradeCount = int.Parse(values[3]);
                List<int> grades = new List<int>();
                for (int j = 0; j < gradeCount; j++)
                {
                    int grade = int.Parse(values[4 + j]);
                    grades.Add(grade);
                }
                Student student = new Student(surname, name, faculty, group, grades);
                container.Add(student);
            }
            return container;
        }

        private static int FindTotalCount(StudentsContainer[] containers)
        {
            int count = 0;
            foreach (StudentsContainer container in containers)
            {
                count += container.Count;
            }
            return count;
        }

        private static StudentsContainer MergeContainers(StudentsContainer[] containers)
        {
            int count = FindTotalCount(containers);
            StudentsContainer merged = new StudentsContainer(Math.Max(count, 1));
            foreach (StudentsContainer container in containers)
            {
                for (int i = 0; i < container.Count; i++)
                {
                    merged.Add(container.Get(i));
                }
            }
            return merged;
        }

        public static StudentsContainer ReadStudents(params string[] filenames)
        {
            StudentsContainer[] containers = new StudentsContainer[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
            {
                string filename = filenames[i];
                containers[i] = ReadStudents(filename);
            }

            return MergeContainers(containers);
        }

        public static void PrintStudents(string label, StudentsContainer container)
        {
            Console.WriteLine(new string('-', 99));
            Console.WriteLine("| {0,-95} |", label);
            Console.WriteLine(new string('-', 99));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-25} | {3,-12} | {4,16} |", "Pavardė", "Vardas", "Fakultetas", "Grupė", "Pažymių vidurkis");
            Console.WriteLine(new string('-', 99));
            for (int i = 0; i < container.Count; i++)
            {
                Student student = container.Get(i);
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-25} | {3,-12} | {4,16:f2} |", student.Surname, student.Name, student.Faculty, student.Group, student.GradesAverage);
            }
            Console.WriteLine(new string('-', 99));
        }
    }
}
