using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Repository.Interfaces
{
    public interface IGobiernosRepository
    {
        Task<List<Gobiernos>> GetAllGobiernos();
        Task<Gobiernos> GetGobierno(int idGobierno);
        Task<Gobiernos> AddGobierno(Gobiernos Gobierno);
        Task<Gobiernos> UpdateGobierno(Gobiernos Gobierno);
        Task<Gobiernos> DeleteGobierno(int idGobierno);
    }
}
