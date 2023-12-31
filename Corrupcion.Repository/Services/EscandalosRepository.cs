﻿using Corrupcion.Helpers;
using Corrupcion.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Corrupcion.Repository.Services
{
    public class EscandalosRepository : IEscandalosRepository
    {
        private readonly CorrupcionContext _corrupcionContext;
        public EscandalosRepository(CorrupcionContext corrupcionContext)
        {
            _corrupcionContext = corrupcionContext;
        }

        public async Task<Escandalos> AddEscandalosAsync(Escandalos escandalo)
        {
            await _corrupcionContext.Escandalos.AddAsync(escandalo);
            await _corrupcionContext.SaveChangesAsync();
            return escandalo;
        }

        public async Task<Escandalos> DeleteEscandalosAsync(int idEscandalo)
        {
            var escandalo = await _corrupcionContext.Escandalos.Where(e => e.IdEscandalo == idEscandalo).FirstOrDefaultAsync();
            _corrupcionContext.Escandalos.Remove(escandalo);
            return escandalo;
        }

        public async Task<List<Escandalos>> GetAllEscandalosAsync()
        {
            return await _corrupcionContext.Escandalos.ToListAsync();
        }

        public async Task<Escandalos> GetEscandaloAsync(int idEscandalo)
        {
            return await _corrupcionContext.Escandalos.FindAsync(idEscandalo);
        }

        public async Task<Escandalos> UpdateEscandalosAsync(Escandalos escandalo)
        {
            
            Escandalos updatedEscandalo = await _corrupcionContext.Escandalos.Where(e => e.IdEscandalo == escandalo.IdEscandalo).FirstOrDefaultAsync();

            updatedEscandalo.IdGobierno = escandalo.IdGobierno;
            _corrupcionContext.Escandalos.Update(updatedEscandalo);
            await _corrupcionContext.SaveChangesAsync();
            return updatedEscandalo;
        }
    }
}