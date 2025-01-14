using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Round
{
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime? Ende { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
