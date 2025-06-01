using dictapi.Dtos;

namespace dictapi.Interfaces
{
    public interface IUseService
    {
            // Todos los usuarios
            Task<List<UsoDtos>> GetUsosByWordIdAsync(int idword);

            // Admin
            Task<bool> CreateUsoAsync(UsoDto dto);
            Task<bool> UpdateUsoAsync(int iduse, UsoUpdateDto dto);
            Task<bool> DeleteUsoAsync(int iduse);
    }
}
