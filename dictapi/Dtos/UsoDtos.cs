namespace dictapi.Dtos
{
    public class UsoDtos
    {
        public int Iduse { get; set; }
        public int Idword { get; set; }
        public string Wuse { get; set; } = null!;
        public string Descrip { get; set; } = null!;
    }
    //Dto para actualizar un uso
    public class UsoUpdateDto
    {
        public string Wuse { get; set; } = null!;
        public string Descrip { get; set; } = null!;
    }
    //Dto para crear un uso
    public class UsoDto
    {
        public int Idword { get; set; }
        public string Wuse { get; set; } = null!;
        public string Descrip { get; set; } = null!;
    }
}
