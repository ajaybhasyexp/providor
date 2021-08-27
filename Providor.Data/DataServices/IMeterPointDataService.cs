using System.Collections;
using System.Collections.Generic;
using Providor.Data.Models;

namespace Providor.Data.DataServices
{
    public interface IMeterPointDataService
    {
        /// <summary>
        /// Gets all the Meter Points
        /// </summary>
        /// <returns>A list of Meter Points</returns>
        IEnumerable<MeterPoint> Get();
        
        /// <summary>
        /// Gets a list of Meter points by MeterId.
        /// </summary>
        /// <param name="meterId">The meter identifier.</param>
        /// <returns>A list of Meter points</returns>
        IEnumerable<MeterPoint> GetByMeter(int meterId);
    }
}