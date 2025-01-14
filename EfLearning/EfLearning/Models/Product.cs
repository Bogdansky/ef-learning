using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Product
{
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime? Ende { get; set; }

    public int? Roundid { get; set; }

    public virtual Round? Round { get; set; }
}
