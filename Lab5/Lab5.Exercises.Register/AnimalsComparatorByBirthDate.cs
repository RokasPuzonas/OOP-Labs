using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByBirthDate : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int birthCompare = a.BirthDate.CompareTo(b.BirthDate);
            if (birthCompare == 0)
            {
                return a.ID.CompareTo(b.ID);
            }
            else
            {
                return birthCompare;
            }
        }
    }
}
