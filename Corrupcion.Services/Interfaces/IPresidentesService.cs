using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Interfaces
{
    public interface IPresidentesService
    {
        Task<List<Presidentes>> GetAllPresidentes();
        Task<Presidentes> GetPresidente(int idPresidente);
        Task<Presidentes> AddPresidente(Presidentes presidente);
        Task<Presidentes> UpdatePresidente(Presidentes presidente);
        Task<Presidentes> DeletePresidente(int idPresidente);
    }
}
