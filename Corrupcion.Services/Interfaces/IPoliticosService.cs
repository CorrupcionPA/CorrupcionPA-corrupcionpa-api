using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Interfaces
{
    public interface IPoliticosService
    {
        Task<List<Politicos>> GetAllPoliticos();
        Task<Politicos> GetPolitico(int idPolitico);
        Task<Politicos> AddPolitico(Politicos politico);
        Task<Politicos> UpdatePolitico(Politicos politico);
        Task<Politicos> DeletePolitico(int idPolitico);
    }
}
