using Corrupcion.Helpers;
using Corrupcion.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Repository.Services
{
    public class PresidentesRepository: IPresidentesRepository
    {
        private readonly CorrupcionContext _corrupcionContext;
        public PresidentesRepository(CorrupcionContext corrupcionContext)
        {
            _corrupcionContext = corrupcionContext;
        }

        public async Task<Presidentes> AddPresidente(Presidentes presidente)
        {
            await _corrupcionContext.Presidentes.AddAsync(presidente);
            await _corrupcionContext.SaveChangesAsync();
            return presidente;
        }

        public async Task<Presidentes> DeletePresidente(int idPresidente)
        {
            Presidentes presidente = await _corrupcionContext.Presidentes.FindAsync(idPresidente);
            _corrupcionContext.Presidentes.Remove(presidente);
            await _corrupcionContext.SaveChangesAsync();
            return presidente;
        }

        public async Task<List<Presidentes>> GetAllPresidentes()
        {
            return await _corrupcionContext.Presidentes.ToListAsync();
        }

        public async Task<Presidentes> GetPresidente(int idPresidente)
        {
            return await _corrupcionContext.Presidentes.FindAsync(idPresidente);
        }

        public async Task<Presidentes> UpdatePresidente(Presidentes presidente)
        {
            Presidentes presidenteToUpdate = await _corrupcionContext.Presidentes.Where(p => p.IdPresidente == presidente.IdPresidente).FirstOrDefaultAsync(); ;
            presidenteToUpdate.NombrePresidente = presidente.NombrePresidente;
            presidenteToUpdate.NombreVicePresidente = presidente.NombreVicePresidente;
            presidenteToUpdate.IdPartido = presidente.IdPartido;

            _corrupcionContext.Presidentes.Update(presidenteToUpdate);
            return presidenteToUpdate;
        }
    }
}
