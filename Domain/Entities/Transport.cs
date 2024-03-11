using System;
using System.Collections.Generic;

namespace Domain.Entities;


public partial class Transport: BaseEntity
{

    public string FlightCarrier { get; set; } = null!;

    public string FlightNumber { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
