using System;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public VehicleDto Vehicle { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
