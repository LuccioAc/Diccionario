using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Services
{
    public class UseService : IUseService
    {
        private readonly DictdbContext _context;

        public UseService(DictdbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUsoAsync(UsoDto dto)
        {
            var palabraExiste = await _context.Palabras.AnyAsync(p => p.Idword == dto.Idword);
            if (!palabraExiste) return false;

            var uso = new Uso
            {
                Idword = dto.Idword,
                Wuse = dto.Wuse,
                Descrip = dto.Descrip
            };

            _context.Usos.Add(uso);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsoAsync(int iduse)
        {
            var uso = await _context.Usos.FindAsync(iduse);
            if (uso == null) return false;

            _context.Usos.Remove(uso);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UsoDtos>> GetUsosByWordIdAsync(int idword)
        {
            return await _context.Usos
                .Where(u => u.Idword == idword)
                .Select(u => new UsoDtos
                {
                    Idword = u.Idword,
                    Wuse = u.Wuse,
                    Descrip = u.Descrip
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUsoAsync(int iduse, UsoUpdateDto dto)
        {
            var uso = await _context.Usos.FindAsync(iduse);
            if (uso == null) return false;

            uso.Wuse = dto.Wuse;
            uso.Descrip = dto.Descrip;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
