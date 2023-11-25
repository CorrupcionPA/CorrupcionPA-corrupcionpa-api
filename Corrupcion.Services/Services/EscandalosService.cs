using Corrupcion.Repository.Interfaces;
using Corrupcion.Services.Interfaces;
using Models;

namespace Corrupcion.Services.Services
{
    public class EscandalosService : IEscandalosService
    {
        private readonly IEscandalosRepository _escandalosRepository;

        public EscandalosService(IEscandalosRepository escandalosRepository)
        {
            _escandalosRepository = escandalosRepository;
        }

        public async Task<Escandalos> AddEscandalosAsync(Escandalos escandalo)
        {
            return await _escandalosRepository.AddEscandalosAsync(escandalo);
        }

        public async Task<Escandalos> DeleteEscandalosAsync(int idEscandalo)
        {
            return await _escandalosRepository.DeleteEscandalosAsync(idEscandalo);
        }

        public async Task<Escandalos> GetEscandaloAsync(int idEscandalo)
        {
            return await _escandalosRepository.GetEscandaloAsync(idEscandalo);
        }

        public async Task<List<Escandalos>> GetAllEscandalosAsync()
        {
            return await _escandalosRepository.GetAllEscandalosAsync();
        }

        public async Task<Escandalos> UpdateEscandalosAsync(Escandalos escandalo)
        {
            return await _escandalosRepository.UpdateEscandalosAsync(escandalo);
        }
    }
}