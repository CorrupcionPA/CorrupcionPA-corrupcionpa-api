using Corrupcion.Helpers;
using Models;

namespace Corrupcion.Repository.Interfaces
{
    public interface IPartidosRepository
    {

        Task<List<Partidos>> GetAllPartidosAsync();
        Task<Partidos> GetPartidoAsync(int idPartido);
        Task<Partidos> UpdatePartidoAsync(Partidos partido);
        Task<Partidos> AddPartidoAsync(Partidos partido);
        Task<Partidos> DeletePartidoAsync(int idPartido);
    }
}
