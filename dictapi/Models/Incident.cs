using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Incident
{
    public int Idinc { get; set; }

    public int? Idusr { get; set; }

    public string Descrip { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual Usuario? IdusrNavigation { get; set; }
}
