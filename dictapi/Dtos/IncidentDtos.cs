namespace dictapi.Dtos
{
    public class IncidentDtos
    {
        public int Idinc { get; set; }
        public long? Idusr { get; set; }
        public string Descrip { get; set; } = null!;
        public bool Activo { get; set; }
    }
    //Dto para crear un incidente con usuario
    public class IncidentGetDtos
    {
        public int Idinc { get; set; }
        public string Descrip { get; set; } = null!;
        public bool Activo { get; set; }
    }
    //Dto para crear un incidente
    public class IncidentCreateDto
    {
        public string Descrip { get; set; } = null!;
    }
    //Dto para actualizar el estado de un incidente
    public class IncidentStatusUpdateDto
    {
        public bool Activo { get; set; }
    }


}
