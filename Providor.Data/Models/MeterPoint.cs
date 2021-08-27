using System.Collections.Generic;

namespace Providor.Data.Models
{
    public class MeterPoint
    {
        /// <summary>
        /// The unique identifier for Meter point
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mpan
        /// </summary>
        public string Mpan { get; set; }

        /// <summary>
        /// The mpan indicator
        /// </summary>
        public string MpanIndicator { get; set; }

        /// <summary>
        /// Foreign key referencefor meters.
        /// </summary>
        public IEnumerable<Meter> Meters { get; set; }
    }
}
