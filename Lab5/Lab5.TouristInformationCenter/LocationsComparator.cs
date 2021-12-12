namespace Lab5.TouristInformationCenter
{
    class LocationsComparator
    {
        public virtual int Compare(Location a, Location b)
        {
            return a.CompareTo(b);
        }
    }
}
