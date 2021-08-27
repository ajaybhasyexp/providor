using System;
using System.Collections.Generic;
using System.Linq;
using Providor.Business.Exceptions;
using Providor.Data.DataServices;
using Providor.Data.Models;

namespace Providor.Business.Services
{
    public class MeterPointService : IMeterPointService
    {
        private readonly IMeterPointDataService _dataService;
        public MeterPointService(IMeterPointDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public IEnumerable<MeterPoint> Get()
        {
            var result = _dataService.Get();
            if (result.Any())
            {
                return result;
            }
            else
            {
                throw new EmptyResultException();
            }
        }

        public IEnumerable<MeterPoint> GetByMeter(int meterId)
        {
            if (meterId <= 0)
                throw new ArgumentNullException("meterId", "The Meter Id param is 0");
                
            var result = _dataService.GetByMeter(meterId);
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