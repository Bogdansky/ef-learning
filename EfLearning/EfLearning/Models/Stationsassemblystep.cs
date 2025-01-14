using System;
using System.Collections.Generic;

namespace EfLearning.Models;

public partial class Stationsassemblystep
{
    public int? Assemblystepid { get; set; }

    public int? Stationid { get; set; }

    public virtual Assemblystep? Assemblystep { get; set; }

    public virtual Station? Station { get; set; }
}
