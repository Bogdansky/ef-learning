using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Station
{
    public int Id { get; set; }

    public string Position { get; set; } = null!;

    public int? Roundid { get; set; }

    public virtual Round? Round { get; set; }
}
