using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Incidente
{
    public int Idinc { get; set; }

    public int? Idusr { get; set; }

    public string Desc { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual Usuario? IdusrNavigation { get; set; }
}
