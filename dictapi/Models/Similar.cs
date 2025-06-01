using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Similar
{
    public int Idsim { get; set; }

    public int Idsimwrd { get; set; }

    public int Idsimwrd2 { get; set; }

    public virtual Palabra Idsimwrd2Navigation { get; set; } = null!;

    public virtual Palabra IdsimwrdNavigation { get; set; } = null!;
}
