using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Sinonimo
{
    public int Idsin { get; set; }

    public int Idsinwrd { get; set; }

    public int Idsinwrd2 { get; set; }

    public virtual Palabra Idsinwrd2Navigation { get; set; } = null!;

    public virtual Palabra IdsinwrdNavigation { get; set; } = null!;
}
