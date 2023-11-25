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
    public class GobiernosRepository: IGobiernosRepository
    {
        private readonly CorrupcionContext _corrupcionContext;
        public GobiernosRepository(CorrupcionContext corrupcionContext) { _corrupcionContext = corrupcionContext; }

        public async Task<Gobiernos> AddGobierno(Gobiernos gobierno)
        {
            await _corrupcionContext.Gobiernos.AddAsync(gobierno);
            await _corrupcionContext.SaveChangesAsync();
            return gobierno;
        }

        public async Task<Gobiernos> DeleteGobierno(int idGobierno)
        {
            Gobiernos gobierno = await _corrupcionContext.Gobiernos.FindAsync(idGobierno);
            _corrupcionContext.Gobiernos.Remove(gobierno);
            await _corrupcionContext.SaveChangesAsync();
            return gobierno;
        }

        public async Task<List<Gobiernos>> GetAllGobiernos()
        {
            return await _corrupcionContext.Gobiernos.ToListAsync();
        }

        public async Task<Gobiernos> GetGobierno(int idGobierno)
        {
            return await _corrupcionContext.Gobiernos.FindAsync(idGobierno);
        }

        public async Task<Gobiernos> UpdateGobierno(Gobiernos gobierno)
        {
            Gobiernos GobiernoToUpdate = await _corrupcionContext.Gobiernos.Where(p => p.IdGobierno == gobierno.IdGobierno).FirstOrDefaultAsync();
            GobiernoToUpdate.IdPartido = gobierno.IdPartido;
            GobiernoToUpdate.IdPresidente = gobierno.IdPresidente;
            GobiernoToUpdate.Presidente = gobierno.Presidente;

            _corrupcionContext.Gobiernos.Update(GobiernoToUpdate);
            return GobiernoToUpdate;
        }
    }
}
