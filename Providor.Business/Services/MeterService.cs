using Providor.Data.DataServices;
using Providor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providor.Business.Services
{
    public class MeterService : IMeterService
    {
        private readonly IMeterDataService _dataService;

        public MeterService(IMeterDataService dataService)
        {
            _dataService = dataService;
        }
        public IEnumerable<Meter> Get()
        {
            return _dataService.GetAll();
        }
    }
}
