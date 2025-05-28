namespace dictapi.Dtos
{
    public class WordDtos
    {
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
        public List<WordRelationDto> Similares { get; set; } = new();
        public List<WordRelationDto> Sinonimos { get; set; } = new();
        public List<WordRelationDto> Antonimos { get; set; } = new();
    }
    public class PalabraCreateDto
    {
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
    }

    public class PalabraUpdateDto
    {
        public string Word { get; set; } = null!;
        public string Meaning { get; set; } = null!;
    }

    public class WordSearchResultDto
    {
        public int Idword { get; set; }
        public string Word { get; set; } = null!;
    }
    public class WordRelationDto
    {
        public int Idword { get; set; }
        public string Word { get; set; } = null!;
    }


}
