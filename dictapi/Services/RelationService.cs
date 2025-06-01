using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Services
{
    public class RelationService : IRelationService
    {
        private readonly DictdbContext _context;

        public RelationService(DictdbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAntonymAsync(AntonymCUDto dto)
        {
            if (dto.Idantwrd == dto.Idantwrd2)
                return false; // No pueden ser iguales

            int id1 = Math.Min(dto.Idantwrd, dto.Idantwrd2);
            int id2 = Math.Max(dto.Idantwrd, dto.Idantwrd2);

            // Verifica existencia de ambas palabras
            bool exist1 = await _context.Palabras.AnyAsync(p => p.Idword == id1);
            bool exist2 = await _context.Palabras.AnyAsync(p => p.Idword == id2);
            if (!exist1 || !exist2) return false;

            var antonimo = new Antonimo
            {
                Idantwrd = id1,
                Idantwrd2 = id2
            };

            try
            {
                _context.Antonimos.Add(antonimo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Violación del UNIQUE
                return false;
            }
        }

        public async Task<bool> CreateSimilarAsync(SimilarCUDto dto)
        {
            if (dto.Idsimwrd == dto.Idsimwrd2)
                return false; // No pueden ser iguales

            int id1 = Math.Min(dto.Idsimwrd, dto.Idsimwrd2);
            int id2 = Math.Max(dto.Idsimwrd, dto.Idsimwrd2);

            // Verifica existencia de ambas palabras
            bool exist1 = await _context.Palabras.AnyAsync(p => p.Idword == id1);
            bool exist2 = await _context.Palabras.AnyAsync(p => p.Idword == id2);
            if (!exist1 || !exist2) return false;

            var similar = new Similar
            {
                Idsimwrd = id1,
                Idsimwrd2 = id2
            };

            try
            {
                _context.Similars.Add(similar);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Violación del UNIQUE
                return false;
            }
        }

        public async Task<bool> CreateSynonymAsync(SynonymCUDto dto)
        {
            if (dto.Idsinwrd == dto.Idsinwrd2)
                return false; // No pueden ser iguales

            int id1 = Math.Min(dto.Idsinwrd, dto.Idsinwrd2);
            int id2 = Math.Max(dto.Idsinwrd, dto.Idsinwrd2);

            // Verifica existencia de ambas palabras
            bool exist1 = await _context.Palabras.AnyAsync(p => p.Idword == id1);
            bool exist2 = await _context.Palabras.AnyAsync(p => p.Idword == id2);
            if (!exist1 || !exist2) return false;

            var sinonimo = new Sinonimo
            {
                Idsinwrd = id1,
                Idsinwrd2 = id2
            };

            try
            {
                _context.Sinonimos.Add(sinonimo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Violación del UNIQUE
                return false;
            }
        }

        public async Task<bool> DeleteAntonymAsync(AntonymCUDto dto)
        {
            if (dto.Idantwrd == dto.Idantwrd2)
                return false;

            int id1 = Math.Min(dto.Idantwrd, dto.Idantwrd2);
            int id2 = Math.Max(dto.Idantwrd, dto.Idantwrd2);

            var existing = await _context.Antonimos
                .FirstOrDefaultAsync(s => s.Idantwrd == id1 && s.Idantwrd2 == id2);

            if (existing == null)
                return false;

            _context.Antonimos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSimilarAsync(SimilarCUDto dto)
        {
            if (dto.Idsimwrd == dto.Idsimwrd2)
                return false;

            int id1 = Math.Min(dto.Idsimwrd, dto.Idsimwrd2);
            int id2 = Math.Max(dto.Idsimwrd, dto.Idsimwrd2);

            var existing = await _context.Similars
                .FirstOrDefaultAsync(s => s.Idsimwrd == id1 && s.Idsimwrd2 == id2);

            if (existing == null)
                return false;

            _context.Similars.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSynonymAsync(SynonymCUDto dto)
        {
            if (dto.Idsinwrd == dto.Idsinwrd2)
                return false;

            int id1 = Math.Min(dto.Idsinwrd, dto.Idsinwrd2);
            int id2 = Math.Max(dto.Idsinwrd, dto.Idsinwrd2);

            var existing = await _context.Sinonimos
                .FirstOrDefaultAsync(s => s.Idsinwrd == id1 && s.Idsinwrd2 == id2);

            if (existing == null)
                return false;

            _context.Sinonimos.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<IdnWordDto>> GetAntonymsAsync(int idWord)
        {
            var antonyms = await _context.Antonimos
                .Where(s => s.Idantwrd == idWord || s.Idantwrd2 == idWord)
                .Select(s => s.Idantwrd == idWord ? s.Idantwrd2 : s.Idantwrd)
                .Distinct()
                .ToListAsync();

            return await _context.Palabras
                .Where(p => antonyms.Contains(p.Idword))
                .Select(p => new IdnWordDto
                {
                    Idword = p.Idword,
                    Word = p.Word
                })
                .ToListAsync();
        }

        public async Task<List<IdnWordDto>> GetSimilarsAsync(int idWord)
        {
            var similars = await _context.Similars
                .Where(s => s.Idsimwrd == idWord || s.Idsimwrd2 == idWord)
                .Select(s => s.Idsimwrd == idWord ? s.Idsimwrd2 : s.Idsimwrd)
                .Distinct()
                .ToListAsync();

            return await _context.Palabras
                .Where(p => similars.Contains(p.Idword))
                .Select(p => new IdnWordDto
                {
                    Idword = p.Idword,
                    Word = p.Word
                })
                .ToListAsync();
        }

        public async Task<List<IdnWordDto>> GetSynonymsAsync(int idWord)
        {
            var synonyms = await _context.Sinonimos
                .Where(s => s.Idsinwrd == idWord || s.Idsinwrd2 == idWord)
                .Select(s => s.Idsinwrd == idWord ? s.Idsinwrd2 : s.Idsinwrd)
                .Distinct()
                .ToListAsync();

            return await _context.Palabras
                .Where(p => synonyms.Contains(p.Idword))
                .Select(p => new IdnWordDto
                {
                    Idword = p.Idword,
                    Word = p.Word
                })
                .ToListAsync();
        }
    }
}
