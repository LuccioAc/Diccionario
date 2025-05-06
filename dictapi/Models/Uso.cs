using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Uso
{
    public int Id { get; set; }

    public int Idword { get; set; }

    public string Desc { get; set; } = null!;

    public virtual Palabra IdwordNavigation { get; set; } = null!;
}
