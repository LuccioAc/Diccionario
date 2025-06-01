using dictapi.Dtos;

namespace dictapi.Interfaces
{
    public interface IRelationService
    {
        Task<bool> CreateSynonymAsync(SynonymCUDto dto);
        Task<bool> DeleteSynonymAsync(SynonymCUDto dto);
        Task<List<IdnWordDto>> GetSynonymsAsync(int idWord);

        Task<bool> CreateAntonymAsync(AntonymCUDto dto);
        Task<bool> DeleteAntonymAsync(AntonymCUDto dto);
        Task<List<IdnWordDto>> GetAntonymsAsync(int idWord);

        Task<bool> CreateSimilarAsync(SimilarCUDto dto);
        Task<bool> DeleteSimilarAsync(SimilarCUDto dto);
        Task<List<IdnWordDto>> GetSimilarsAsync(int idWord);
    }
}
