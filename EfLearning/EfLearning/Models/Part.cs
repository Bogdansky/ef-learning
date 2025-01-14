using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Part
{
    public int? Productid { get; set; }

    public int? Partdefinitionid { get; set; }

    public virtual Partdefinition? Partdefinition { get; set; }

    public virtual Product? Product { get; set; }
}
