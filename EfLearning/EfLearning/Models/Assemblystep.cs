using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Assemblystep
{
    public int Id { get; set; }

    public int Cost { get; set; }

    public string Name { get; set; } = null!;
}
