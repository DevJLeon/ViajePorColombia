using System;
using System.Collections.Generic;

namespace Domain.Entities;


public partial class Journeyflight
{
    public int FlightId { get; set; }

    public int JourneyId { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Journey Journey { get; set; } = null!;
}
