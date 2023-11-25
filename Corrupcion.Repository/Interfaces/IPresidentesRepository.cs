using Models;

namespace Corrupcion.Repository.Interfaces
{
    public interface IPresidentesRepository
    {
        Task<List<Presidentes>> GetAllPresidentes();
        Task<Presidentes> GetPresidente(int idPresidente);
        Task<Presidentes> AddPresidente(Presidentes presidente);
        Task<Presidentes> UpdatePresidente(Presidentes presidente);
        Task<Presidentes> DeletePresidente(int idPresidente);
    }
}
