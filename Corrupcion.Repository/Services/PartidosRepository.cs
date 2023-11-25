using Corrupcion.Helpers;
using Corrupcion.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Corrupcion.Repository.Services
{
    public class PartidosRepository: IPartidosRepository
    {
        private readonly CorrupcionContext _corrupcionContext;
        public PartidosRepository(CorrupcionContext corrupcionContext)
        {
            _corrupcionContext = corrupcionContext;
        }
        public async Task<Partidos> AddPartidoAsync(Partidos partido)
        {
            await _corrupcionContext.Partidos.AddAsync(partido);
            await _corrupcionContext.SaveChangesAsync();
            return partido;
        }

        public async Task<Partidos> DeletePartidoAsync(int idPartido)
        {
            Partidos partido = await _corrupcionContext.Partidos.FindAsync(idPartido);
            _corrupcionContext.Partidos.Remove(partido);
            return partido;
        }

        public async Task<List<Partidos>> GetAllPartidosAsync()
        {
            return await _corrupcionContext.Partidos.ToListAsync();
        }

        public async Task<Partidos> GetPartidoAsync(int idPartido)
        {
            return await _corrupcionContext.Partidos.FindAsync(idPartido);
        }

        public async Task<Partidos> UpdatePartidoAsync(Partidos partido)
        {
            Partidos updatedPartido = await _corrupcionContext.Partidos.Where(p => p.IdPartido == partido.IdPartido).FirstOrDefaultAsync();

            updatedPartido.NombrePartido = partido.NombrePartido;
            updatedPartido.NombreAbreviado = partido.NombreAbreviado;
            updatedPartido.FechaCreacion = partido.FechaCreacion;

            _corrupcionContext.Partidos.Update(updatedPartido);
            await _corrupcionContext.SaveChangesAsync();

            return updatedPartido;
        }
    }
}
