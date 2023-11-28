using Corrupcion.Repository.Interfaces;
using Corrupcion.Services.Interfaces;
using Models;

namespace Corrupcion.Services.Services
{
    public class PoliticosService : IPoliticosService
    {
        private readonly IPoliticosRepository _politicosRepository;
        public PoliticosService(IPoliticosRepository politicosRepository)
        {
            _politicosRepository = politicosRepository;
        }
        public Task<Politicos> AddPolitico(Politicos politico)
        {
            return _politicosRepository.AddPolitico(politico);
        }

        public Task<Politicos> DeletePolitico(int idPolitico)
        {
            return _politicosRepository.DeletePolitico(idPolitico);
        }

        public Task<List<Politicos>> GetAllPoliticos()
        {
            return _politicosRepository.GetAllPoliticos();
        }

        public Task<Politicos> GetPolitico(int idPolitico)
        {
            return _politicosRepository.GetPolitico(idPolitico);
        }

        public Task<Politicos> UpdatePolitico(Politicos politico)
        {
            return _politicosRepository.UpdatePolitico(politico);
        }
    }
}
