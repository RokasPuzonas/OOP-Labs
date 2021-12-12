namespace Lab5.TouristInformationCenter
{
    class LocationsComparatorByNameAddress : LocationsComparator
    {
        public override int Compare(Location a, Location b)
        {
            int nameCompare = a.Name.CompareTo(b.Name);
            if (nameCompare == 0)
            {
                return a.Address.CompareTo(b.Address);
            } else
            {
                return nameCompare;
            }
        }
    }
}
