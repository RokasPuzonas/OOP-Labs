using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Exercises.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        private int Capacity;
        public int Count { get; private set; }

        public DogsContainer(int capacity = 16)
        {
            Capacity = capacity;
            dogs = new Dog[capacity];
        }

        public DogsContainer(DogsContainer container) : this(container.Capacity) //call another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                Add(container.Get(i));
            }
        }

        public void Add(Dog dog)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            dogs[Count] = dog;
            Count++;
        }
        public Dog Get(int index)
        {
            return dogs[index];
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if (dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(int index, Dog dog)
        {
            dogs[index] = dog;
        }

        public void Insert(int index, Dog dog)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            for (int i = Count+1; i > index; i--)
            {
                dogs[i] = dogs[i-1];
            }
            dogs[index] = dog;
            Count++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                dogs[i] = dogs[i + 1];
            }
            Count--;
        }

        public void Remove(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if (dogs[i].ID == dog.ID)
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
                Dog[] dogsClone = new Dog[minimumCapacity];
                for (int i = 0; i < Count; i++)
                {
                    dogsClone[i] = dogs[i];
                }
                Capacity = minimumCapacity;
                dogs = dogsClone;
            }
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < Count; i++)
            {
                Dog current = dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }



    }

}
