using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Palabra
{
    public int Idword { get; set; }

    public string Word { get; set; } = null!;

    public string Meaning { get; set; } = null!;

    public virtual ICollection<Antonimo> AntonimoIdantwrd2Navigations { get; set; } = new List<Antonimo>();

    public virtual ICollection<Antonimo> AntonimoIdantwrdNavigations { get; set; } = new List<Antonimo>();

    public virtual ICollection<Similar> SimilarIdsimwrd2Navigations { get; set; } = new List<Similar>();

    public virtual ICollection<Similar> SimilarIdsimwrdNavigations { get; set; } = new List<Similar>();

    public virtual ICollection<Sinonimo> SinonimoIdsinwrd2Navigations { get; set; } = new List<Sinonimo>();

    public virtual ICollection<Sinonimo> SinonimoIdsinwrdNavigations { get; set; } = new List<Sinonimo>();

    public virtual ICollection<Uso> Usos { get; set; } = new List<Uso>();
}
