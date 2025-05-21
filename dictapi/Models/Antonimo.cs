using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Antonimo
{
    public int Idant { get; set; }

    public int Idantwrd { get; set; }

    public int Idantwrd2 { get; set; }

    public virtual Palabra Idantwrd2Navigation { get; set; } = null!;

    public virtual Palabra IdantwrdNavigation { get; set; } = null!;
}
