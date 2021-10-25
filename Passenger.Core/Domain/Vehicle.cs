using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }

        public Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(name);
            SetSeats(seats);
        }
        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Brand can not be empty.");
            }
            if (Brand == brand) return;
            Brand = brand;
        }
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name can not be empty.");
            }
            if (Name == name) return;
            Name = name;
        }
        private void SetSeats(int seats)
        {
            if (seats < 0)
                throw new Exception("Seats");
            if (seats > 9)
                throw new Exception("You can not provide more then 9 seats");
            Seats = seats;
        }

        public static Vehicle Create(string brand, string name, int seats) =>
            new Vehicle(brand, name, seats);
    }
}
