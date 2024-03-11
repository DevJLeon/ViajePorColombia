using System;
using System.Collections.Generic;

namespace Domain.Entities;


public partial class Flight : BaseEntity
{

    public int TransportId { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public double Price { get; set; }

    public virtual Journeyflight? Journeyflight { get; set; }

    public virtual Transport Transport { get; set; } = null!;
}
