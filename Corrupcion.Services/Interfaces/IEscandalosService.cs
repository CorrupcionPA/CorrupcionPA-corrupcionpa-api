using Models;

namespace Corrupcion.Services.Interfaces
{
    public interface IEscandalosService
    {
        Task<List<Escandalos>> GetAllEscandalosAsync();
        Task<Escandalos> GetEscandaloAsync(int idEscandalo);
        Task<Escandalos> AddEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> UpdateEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> DeleteEscandalosAsync(int idEscandalo);
    }
}
