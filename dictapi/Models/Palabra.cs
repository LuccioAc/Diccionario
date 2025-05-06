using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Palabra
{
    public int Idword { get; set; }

    public string Word { get; set; } = null!;

    public string Meaning { get; set; } = null!;

    public virtual ICollection<Similare> SimilareIdwordNavigations { get; set; } = new List<Similare>();

    public virtual ICollection<Similare> SimilareIdwsimiNavigations { get; set; } = new List<Similare>();

    public virtual ICollection<Uso> Usos { get; set; } = new List<Uso>();
}
