using dictapi.Dtos;

namespace dictapi.Interfaces
{
    public interface IWordService
    {
        Task<List<IdnWordDto>> SearchWordAsync();
        Task<WordDtos?> GetFullWordAsync(int id);

        // Solo Admin
        Task<bool> CreateWordAsync(WordnMeaningDto newrd);
        Task<bool> UpdateWordAsync(int id, WordnMeaningDto dto);
        Task<bool> DeleteWordAsync(int id);
    }
}
