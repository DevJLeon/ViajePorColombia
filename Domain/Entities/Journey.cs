using System;
using System.Collections.Generic;

namespace Domain.Entities;


public partial class Journey : BaseEntity
{

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Journeyflight> Journeyflights { get; set; } = new List<Journeyflight>();
}
