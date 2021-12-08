using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class AnimalsContainer
    {
        private Animal[] animals;
        private int Capacity;
        public int Count { get; private set; }

        public AnimalsContainer(int capacity = 16)
        {
            Capacity = capacity;
            animals = new Animal[capacity];
        }

        public AnimalsContainer(AnimalsContainer container) : this(container.Capacity) //call another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                Add(container.Get(i));
            }
        }

        public void Add(Animal animal)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            animals[Count] = animal;
            Count++;
        }
        public Animal Get(int index)
        {
            return animals[index];
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < Count; i++)
            {
                if (animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Animal animal)
        {
            animals[index] = animal;
        }

        public void Insert(int index, Animal animal)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count+1; i > index; i--)
            {
                animals[i] = animals[i-1];
            }
            animals[index] = animal;
            Count++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                animals[i] = animals[i + 1];
            }
            Count--;
        }

        public void Remove(Animal animal)
        {
            for (int i = 0; i < Count; i++)
            {
                if (animals[i].ID == animal.ID)
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
                Animal[] animalsClone = new Animal[minimumCapacity];
                for (int i = 0; i < Count; i++)
                {
                    animalsClone[i] = animals[i];
                }
                Capacity = minimumCapacity;
                animals = animalsClone;
            }
        }

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < Count; i++)
            {
                Animal current = animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }



    }

}
