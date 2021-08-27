using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Providor.Data.Models;

namespace Providor.Data.DataServices
{
    public class MeterPointDataService : IMeterPointDataService
    {
        private readonly ProvidorDBContext _context;

        public MeterPointDataService(ProvidorDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MeterPoint> Get()
        {
            return _context.MeterPoints.Include(p=>p.Meters).ToList();
        }

        public IEnumerable<MeterPoint> GetByMeter(int meterId)
        {
            return _context.MeterPoints.Include(p=>p.Meters).Where(p=>p.Meters.Any(p=>p.Id == meterId));
        }
    }
}