using System;
using System.Collections.Generic;

namespace dictapi.Models;

public partial class Usuario
{
    public long Idusr { get; set; }

    public string Nameusr { get; set; } = null!;

    public string Passw { get; set; } = null!;

    public string? Codeusr { get; set; }

    public bool Rol { get; set; }

    public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}
