using Models;

namespace Corrupcion.Services.Interfaces
{
    public interface IEscandalosService
    {
        Task<List<Escandalos>> GetAllEscandalosAsync();
        Task<Escandalos> GetEscandaloAsync(Guid idEscandalo);
        Task<Escandalos> AddEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> UpdateEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> DeleteEscandalosAsync(Guid idEscandalo);
    }
}
