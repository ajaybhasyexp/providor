using Providor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providor.Business.Services
{
    public interface IMeterService
    {
        IEnumerable<Meter> Get();
    }
}
