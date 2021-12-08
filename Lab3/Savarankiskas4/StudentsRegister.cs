using System;
using System.Collections.Generic;
using System.Text;

namespace Savarankiskas4
{
    class StudentsRegister
    {
        private StudentsContainer students;
        public StudentsRegister()
        {
            students = new StudentsContainer();
        }
        public StudentsRegister(StudentsContainer container)
        {
            students = new StudentsContainer();
            for (int i = 0; i < container.Count; i++)
            {
                students.Add(container.Get(i));
            }
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public Student Get(int index)
        {
            return students.Get(index);
        }

        public int StudentsCount()
        {
            return students.Count;
        }

        public List<string> FindAllGroups()
        {
            List<string> groups = new List<string>();
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                if (!groups.Contains(student.Group))
                {
                    groups.Add(student.Group);
                }
            }
            return groups;
        }

        public float FindGradesAverageByGroup(string group)
        {
            float sum = 0;
            int n = 0;
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                if (student.Group == group)
                {
                    sum += student.GradesAverage;
                    n++;
                }
            }
            return sum / n;
        }

        public List<Tuple<string, float>> FindGradesAverages()
        {
            List<string> groups = FindAllGroups();
            List<Tuple<string, float>> averages = new List<Tuple<string, float>>();
            foreach (string group in groups)
            {
                float average = FindGradesAverageByGroup(group);
                averages.Add(new Tuple<string, float>(group, average));
            }

            averages.Sort(delegate (Tuple<string, float> group1, Tuple<string, float> group2) {
                int gradesComparison = -group1.Item2.CompareTo(group2.Item2);
                if (gradesComparison == 0)
                {
                    return group1.Item1.CompareTo(group2.Item1);
                } else
                {
                    return gradesComparison;
                }
            });

            return averages;
        }

    }
}
