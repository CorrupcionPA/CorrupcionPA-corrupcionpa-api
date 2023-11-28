using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Interfaces
{
    public interface IPartidosService
    {
        Task<List<Partidos>> GetAllPartidosAsync();
        Task<Partidos> GetPartidoAsync(Guid idPartido);
        Task<Partidos> UpdatePartidoAsync(Partidos partido);
        Task<Partidos> AddPartidoAsync(Partidos partido);
        Task<Partidos> DeletePartidoAsync(Guid idPartido);
    }
}
