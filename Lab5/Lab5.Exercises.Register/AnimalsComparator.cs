using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class AnimalsComparator
    {
        public virtual int Compare(Animal a, Animal b)
        {
            return a.CompareTo(b);
        }
    }
}
