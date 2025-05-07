using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Similar
{
    public int Id { get; set; }

    public int Idword { get; set; }

    public int Idwsimi { get; set; }

    public virtual Palabra IdwordNavigation { get; set; } = null!;

    public virtual Palabra IdwsimiNavigation { get; set; } = null!;
}
