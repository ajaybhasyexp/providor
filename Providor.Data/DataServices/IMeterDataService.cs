using Providor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providor.Data.DataServices
{
    /// <summary>
    /// The data service 
    /// </summary>
    public interface IMeterDataService
    {
        /// <summary>
        /// Gets all Meter entities.
        /// </summary>
        /// <returns>A list of metrer entities</returns>
        IEnumerable<Meter> GetAll();
    }
}
