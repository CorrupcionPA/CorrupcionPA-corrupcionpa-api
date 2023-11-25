using Corrupcion.Repository.Interfaces;
using Corrupcion.Services.Interfaces;
using Models;

namespace Corrupcion.Services.Services
{
    public class PresidentesService : IPresidentesService
    {
        private readonly IPresidentesRepository _presidentesRepository;
        public PresidentesService(IPresidentesRepository presidentesRepository)
        {
            _presidentesRepository = presidentesRepository;
        }
        public Task<Presidentes> AddPresidente(Presidentes presidente)
        {
            return _presidentesRepository.AddPresidente(presidente);
        }

        public Task<Presidentes> DeletePresidente(int idPresidente)
        {
            return _presidentesRepository.DeletePresidente(idPresidente);
        }

        public Task<List<Presidentes>> GetAllPresidentes()
        {
            return _presidentesRepository.GetAllPresidentes();
        }

        public Task<Presidentes> GetPresidente(int idPresidente)
        {
            return _presidentesRepository.GetPresidente(idPresidente);
        }

        public Task<Presidentes> UpdatePresidente(Presidentes presidente)
        {
            return _presidentesRepository.UpdatePresidente(presidente);
        }
    }
}
