using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Partdefinition
{
    public int Id { get; set; }

    public int Cost { get; set; }

    public string Name { get; set; } = null!;
}
