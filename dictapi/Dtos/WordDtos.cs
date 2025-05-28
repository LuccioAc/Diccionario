namespace dictapi.Dtos
{
    public class WordDtos
    {
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
        public List<IdnWordDto> Similares { get; set; } = new();
        public List<IdnWordDto> Sinonimos { get; set; } = new();
        public List<IdnWordDto> Antonimos { get; set; } = new();
    }
    //Dto para crear y modificar palabras
    public class WordnMeaningDto
    {
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
    }
    //Dto para resultado en lista de busqueda y relación entre palabras
    public class IdnWordDto
    {
        public int Idword { get; set; }
        public string Word { get; set; } = null!;
    }
}
