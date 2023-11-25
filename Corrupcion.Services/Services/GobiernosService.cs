using Corrupcion.Repository.Interfaces;
using Corrupcion.Services.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupcion.Services.Services
{
    public class GobiernosService: IGobiernosService
    {
        private readonly IGobiernosRepository _gobiernosRepository;
        public GobiernosService(IGobiernosRepository gobiernosRepository)
        {
            _gobiernosRepository = gobiernosRepository;
        }
        public Task<Gobiernos> AddGobierno(Gobiernos gobierno)
        {
            return _gobiernosRepository.AddGobierno(gobierno);
        }

        public Task<Gobiernos> DeleteGobierno(int idGobierno)
        {
            return _gobiernosRepository.DeleteGobierno(idGobierno);
        }

        public Task<List<Gobiernos>> GetAllGobiernos()
        {
            return _gobiernosRepository.GetAllGobiernos();
        }

        public Task<Gobiernos> GetGobierno(int idGobierno)
        {
            return _gobiernosRepository.GetGobierno(idGobierno);
        }

        public Task<Gobiernos> UpdateGobierno(Gobiernos gobierno)
        {
            return _gobiernosRepository.UpdateGobierno(gobierno);
        }
    }
}
