using System;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace ReEntry.WebAPI.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Make { get; private set; }
        public string PlateNumber { get; private set; }
        public int ProductionYear { get; private set; }

        public Car(string make, string plateNumber, int productionYear)
        {
            Make = make;
            PlateNumber = plateNumber;
            ProductionYear = productionYear;
        }

        public Car Copy()
        {
            return new Car(Make, PlateNumber, ProductionYear);
        }
    }
}