using System;
using System.Collections.Generic;
using System.Text;

namespace Savarankiskas4
{
    class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Group { get; set; }
        public List<int> Grades { get; set; }
        public float GradesAverage
        {
            get
            {
                float sum = 0;
                foreach (int grade in Grades)
                {
                    sum += grade;
                }
                return sum/Grades.Count;
            }
        }

        public Student(string surname, string name, string faculty, string group, List<int> grades)
        {
            Surname = surname;
            Name = name;
            Faculty = faculty;
            Group = group;
            Grades = grades;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   Surname == student.Surname &&
                   Name == student.Name &&
                   Faculty == student.Faculty &&
                   Group == student.Group;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Surname, Name, Faculty, Group);
        }

    }
}
