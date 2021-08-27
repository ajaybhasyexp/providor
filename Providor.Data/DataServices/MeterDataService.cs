using Providor.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Providor.Data.DataServices
{
    public class MeterDataService : IMeterDataService
    {
        private readonly ProvidorDBContext _context;
        public MeterDataService(ProvidorDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Meter> GetAll()
        {
            return _context.Meters.ToList();
        }
    }
}
