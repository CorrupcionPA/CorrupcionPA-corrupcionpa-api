using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Interfaces
{
    public interface IGobiernosService
    {
        Task<List<Gobiernos>> GetAllGobiernos();
        Task<Gobiernos> GetGobierno(int idGobierno);
        Task<Gobiernos> AddGobierno(Gobiernos gobierno);
        Task<Gobiernos> UpdateGobierno(Gobiernos gobierno);
        Task<Gobiernos> DeleteGobierno(int idGobierno);
    }
}
