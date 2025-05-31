using AutoMapper;
using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Services
{
    public class WordService : IWordService
    {
        private readonly DictdbContext _context;
        private readonly IMapper _mapper;
        private readonly IRelationService _relationService;
        private readonly IUseService _useService;

        public WordService(DictdbContext context, IMapper mapper, IRelationService relationService, IUseService useService)
        {
            _context = context;
            _mapper = mapper;
            _relationService = relationService;
            _useService = useService;
        }

        public async Task<List<IdnWordDto>> SearchWordAsync()
        {
            var palabras = await _context.Palabras
                .Select(p => new IdnWordDto
                {
                    Idword = p.Idword,
                    Word = p.Word
                }).ToListAsync();

            return palabras;
        }

        public async Task<bool> CreateWordAsync(WordnMeaningDto newrd)
        {
            var existe = await _context.Palabras.AnyAsync(p => p.Word == newrd.Word);
            if (existe) return false;

            var palabra = _mapper.Map<Palabra>(newrd);
            _context.Palabras.Add(palabra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteWordAsync(int id)
        {
            var palabra = await _context.Palabras.FindAsync(id);
            if (palabra == null) return false;

            _context.Palabras.Remove(palabra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateWordAsync(int id, WordnMeaningDto dto)
        {
            var palabra = await _context.Palabras.FindAsync(id);
            if (palabra == null) return false;

            palabra.Word = dto.Word;
            palabra.Meaning = dto.Meaning;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<WordDtos?> GetFullWordAsync(int id)
        {
            var palabra = await _context.Palabras.FirstOrDefaultAsync(p => p.Idword == id);
            if (palabra == null) return null;

            var palabraDto = _mapper.Map<WordDtos>(palabra);

            palabraDto.Similares = await _relationService.GetSimilarsAsync(id);
            palabraDto.Sinonimos = await _relationService.GetSynonymsAsync(id);
            palabraDto.Antonimos = await _relationService.GetAntonymsAsync(id);
            palabraDto.Usos = await _useService.GetUsosByWordIdAsync(id);

            return palabraDto;
        }
    }
}
