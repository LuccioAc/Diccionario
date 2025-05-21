using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Uso
{
    public int Iduse { get; set; }

    public int Idword { get; set; }

    public string Wuse { get; set; } = null!;

    public string Descrip { get; set; } = null!;

    public virtual Palabra IdwordNavigation { get; set; } = null!;
}
