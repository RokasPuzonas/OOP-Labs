using System;
using System.Collections.Generic;
using System.Text;

namespace Savarankiskas4
{
    class StudentsContainer
    {
        private int Capacity;
        public int Count { get; private set; } = 0;
        private Student[] students;
        public StudentsContainer(int capacity = 16)
        {
            Capacity = capacity;
            students = new Student[capacity];
        }

        public void Add(Student student)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            students[Count] = student;
            Count++;
        }

        public void Put(int index, Student student)
        {
            students[index] = student;
        }

        public Student Get(int index)
        {
            return students[index];
        }

        public bool Contains(Student student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(int index, Student student)
        {
            for (int i = Count + 1; i > index; i--)
            {
                students[i] = students[i - 1];
            }
            students[index] = student;
            Count++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                students[i] = students[i + 1];
            }
            Count--;
        }

        public void Remove(Student student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (students[i].Equals(student))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > Capacity)
            {
                Student[] dogsClone = new Student[minimumCapacity];
                for (int i = 0; i < Count; i++)
                {
                    dogsClone[i] = students[i];
                }
                Capacity = minimumCapacity;
                students = dogsClone;
            }
        }
        
    }
}
