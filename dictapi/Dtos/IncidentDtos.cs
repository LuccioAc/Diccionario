namespace dictapi.Dtos
{
    public class IncidentDtos
    {
        public int Idinc { get; set; }
        public string Descrip { get; set; } = null!;
        public bool Activo { get; set; }
    }
    public class IncidentCreateDto
    {
        public string Descrip { get; set; } = null!;
    }
    public class IncidentStatusUpdateDto
    {
        public bool Activo { get; set; }
    }


}
