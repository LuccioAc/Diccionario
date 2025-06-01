using dictapi.Dtos;

namespace dictapi.Interfaces
{
    public interface IIncidentService
    {
        // Usuario
        Task<bool> CreateIncidentAsync(string codeusr, IncidentCreateDto dto);

        // Admin
        Task<List<IncidentGetDtos>> GetAllIncidentsAsync();
        Task<bool> ChangeIncidentStateAsync(int idinc, bool activo);
        Task<bool> DeleteIncidentAsync(int idinc);
    }
}
