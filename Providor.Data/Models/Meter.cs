namespace Providor.Data.Models
{
    /// <summary>
    /// The entity for meter
    /// </summary>
    public class Meter
    {
        /// <summary>
        /// The unique identifier for the meter
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The type of meter (Gas or Electric)
        /// </summary>
        public MeterType MeterType { get; set; }

        /// <summary>
        /// The mode of operation (Credit or Prepaid)
        /// </summary>
        public OperatingMode OperatingMode { get; set; }

        /// <summary>
        /// The number of registers against the Meter.
        /// </summary>
        public int NumberOfRegisters { get; set; }
    }
}