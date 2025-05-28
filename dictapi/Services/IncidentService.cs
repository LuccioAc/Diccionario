using dictapi.Dtos;
using dictapi.Interfaces;
using dictapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly DictdbContext _context;

        public IncidentService(DictdbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeIncidentStateAsync(int idinc, bool activo)
        {
            var incidente = await _context.Incidents.FindAsync(idinc);
            if (incidente == null) return false;

            incidente.Activo = activo;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateIncidentAsync(string codeusr, IncidentCreateDto dto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Codeusr == codeusr);
            if (user == null) return false;

            var incidente = new Incident
            {
                Idusr = user.Idusr,
                Descrip = dto.Descrip,
                Activo = true
            };

            _context.Incidents.Add(incidente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIncidentAsync(int idinc)
        {
            var incidente = await _context.Incidents.FindAsync(idinc);
            if (incidente == null) return false;

            _context.Incidents.Remove(incidente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<IncidentGetDtos>> GetAllIncidentsAsync()
        {
            return await _context.Incidents
                .Select(i => new IncidentGetDtos
                {
                    Idinc = i.Idinc,
                    Descrip = i.Descrip,
                    Activo = i.Activo
                })
                .ToListAsync();
        }
    }
}
