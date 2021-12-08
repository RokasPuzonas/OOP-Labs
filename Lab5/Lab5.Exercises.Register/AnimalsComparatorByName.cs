using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByName : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int nameCompare = a.Name.CompareTo(b.Name);
            if (nameCompare == 0)
            {
                return a.ID.CompareTo(b.ID);
            } else
            {
                return nameCompare;
            }
        }
    }
}
