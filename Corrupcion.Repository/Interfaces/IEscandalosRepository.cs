using Models;

namespace Corrupcion.Repository.Interfaces
{
    public interface IEscandalosRepository
    {
        Task<List<Escandalos>> GetAllEscandalosAsync();
        Task<Escandalos> GetEscandaloAsync(int idEscandalo);
        Task<Escandalos> AddEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> UpdateEscandalosAsync(Escandalos escandalo);
        Task<Escandalos> DeleteEscandalosAsync(int idEscandalo);
    }
}
