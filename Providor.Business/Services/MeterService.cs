using Providor.Business.Exceptions;
using Providor.Data.DataServices;
using Providor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Providor.Business.Services
{
    public class MeterService : IMeterService
    {
        private readonly IMeterDataService _dataService;

        public MeterService(IMeterDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
        public IEnumerable<Meter> Get()
        {
            var result = _dataService.GetAll();
            if (result.Any())
            {
                return result;
            }
            else
            {
                throw new EmptyResultException();
            }

        }
    }
}
