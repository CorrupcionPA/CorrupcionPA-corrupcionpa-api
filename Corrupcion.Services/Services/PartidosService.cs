using Corrupcion.Repository.Interfaces;
using Corrupcion.Services.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Services
{
    public class PartidosService : IPartidosService
    {
        private readonly IPartidosRepository _partidosRepository;
        public PartidosService(IPartidosRepository partidosRepository)
        {
            _partidosRepository = partidosRepository;
        }
        public Task<Partidos> AddPartidoAsync(Partidos partido)
        {
            return _partidosRepository.AddPartidoAsync(partido);
        }

        public Task<Partidos> DeletePartidoAsync(int idPartido)
        {
            return _partidosRepository.DeletePartidoAsync(idPartido);
        }

        public Task<List<Partidos>> GetAllPartidosAsync()
        {
            return _partidosRepository.GetAllPartidosAsync();
        }

        public Task<Partidos> GetPartidoAsync(int idPartido)
        {
            return _partidosRepository.GetPartidoAsync(idPartido);
        }

        public Task<Partidos> UpdatePartidoAsync(Partidos partido)
        {
            return _partidosRepository.UpdatePartidoAsync(partido);
        }
    }
}
