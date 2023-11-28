using Models;

namespace Corrupcion.Repository.Interfaces
{
    public interface IPoliticosRepository
    {
        Task<List<Politicos>> GetAllPoliticos();
        Task<Politicos> GetPolitico(int idPresidente);
        Task<Politicos> AddPolitico(Politicos presidente);
        Task<Politicos> UpdatePolitico(Politicos presidente);
        Task<Politicos> DeletePolitico(int idPresidente);
    }
}
