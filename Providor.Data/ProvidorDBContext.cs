using Microsoft.EntityFrameworkCore;
using Providor.Data.Models;

namespace Providor.Data
{
    public class ProvidorDBContext : DbContext
    {
        public ProvidorDBContext(DbContextOptions<ProvidorDBContext> options) : base(options)
        {
        }

        public DbSet<Meter> Meters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var meter = modelbuilder.Entity<Meter>();
            meter.HasKey(p => p.Id);
            meter.HasData(new Meter { Id=1, MeterType = MeterType.Gas, NumberOfRegisters = 2, OperatingMode = OperatingMode.Credit });
            meter.HasData(new Meter { Id=2, MeterType = MeterType.Electric, NumberOfRegisters = 1, OperatingMode = OperatingMode.Credit });
        }
    }
}
