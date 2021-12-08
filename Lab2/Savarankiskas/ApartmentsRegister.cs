using System;
using System.Collections.Generic;
using System.Text;

namespace Savarankiskas
{
    class ApartmentsRegister
    {
        private List<Apartment> AllApartments;
        public ApartmentsRegister()
        {
            AllApartments = new List<Apartment>();
        }
        public ApartmentsRegister(List<Apartment> apartments)
        {
            AllApartments = new List<Apartment>();
            foreach (Apartment apartment in apartments)
            {
                Add(apartment);
            }
        }

        public void Add(Apartment apartment)
        {
            AllApartments.Add(apartment);
        }

        public int Count()
        {
            return AllApartments.Count;
        }

        public Apartment GetApartment(int index)
        {
            return AllApartments[index];
        }

        public static List<Apartment> FilterByRoomCount(List<Apartment> apartments, int roomCount)
        {
            List<Apartment> Filtered = new List<Apartment>();
            foreach (Apartment apartment in apartments)
            {
                if (apartment.RoomCount == roomCount)
                {
                    Filtered.Add(apartment);
                }
            }
            return Filtered;
        }

        public List<Apartment> FilterByRoomCount(int roomCount)
        {
            return FilterByRoomCount(AllApartments, roomCount);
        }

        public static List<Apartment> FilterByPrice(List<Apartment> apartments, double maxPrice)
        {
            List<Apartment> Filtered = new List<Apartment>();
            foreach (Apartment apartment in apartments)
            {
                if (apartment.Price <= maxPrice)
                {
                    Filtered.Add(apartment);
                }
            }
            return Filtered;
        }

        public List<Apartment> FilterByPrice(double maxPrice)
        {
            return FilterByPrice(AllApartments, maxPrice);
        }

        public static List<Apartment> FilterByFloor(List<Apartment> apartments, int minFloor, int maxFloor)
        {
            List<Apartment> Filtered = new List<Apartment>();
            foreach (Apartment apartment in apartments)
            {
                if (apartment.Floor >= minFloor && apartment.Floor <= maxFloor)
                {
                    Filtered.Add(apartment);
                }
            }
            return Filtered;
        }

        public List<Apartment> FilterByFloor(int minFloor, int maxFloor)
        {
            return FilterByFloor(AllApartments, minFloor, maxFloor);
        }
    }
}
