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
    public class PoliticosRepository: IPoliticosRepository
    {
        private readonly CorrupcionContext _corrupcionContext;
        public PoliticosRepository(CorrupcionContext corrupcionContext)
        {
            _corrupcionContext = corrupcionContext;
        }

        public async Task<Politicos> AddPolitico(Politicos politico)
        {
            await _corrupcionContext.Politicos.AddAsync(politico);
            await _corrupcionContext.SaveChangesAsync();
            return politico;
        }

        public async Task<Politicos> DeletePolitico(int idPolitico)
        {
            Politicos politico = await _corrupcionContext.Politicos.FindAsync(idPolitico);
            _corrupcionContext.Politicos.Remove(politico);
            await _corrupcionContext.SaveChangesAsync();
            return politico;
        }

        public async Task<List<Politicos>> GetAllPoliticos()
        {
            return await _corrupcionContext.Politicos.ToListAsync();
        }

        public async Task<Politicos> GetPolitico(int idPolitico)
        {
            return await _corrupcionContext.Politicos.FindAsync(idPolitico);
        }

        public async Task<Politicos> UpdatePolitico(Politicos politico)
        {
            Politicos politicoToUpdate = await _corrupcionContext.Politicos.Where(p => p.Id == politico.Id).FirstOrDefaultAsync(); ;
            politicoToUpdate.IdPartido = politico.IdPartido;
            politicoToUpdate.Nombre = politico.Nombre;
            politicoToUpdate.InicioPeriodo = politico.InicioPeriodo;
            politicoToUpdate.FinPeriodo = politico.FinPeriodo;

            _corrupcionContext.Politicos.Update(politicoToUpdate);
            return politicoToUpdate;
        }
    }
}
