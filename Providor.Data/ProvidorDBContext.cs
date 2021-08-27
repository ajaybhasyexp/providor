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

        public DbSet<MeterPoint> MeterPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var meterPoint = modelbuilder.Entity<MeterPoint>();
            meterPoint.HasKey(prop => prop.Id);
            var meterPoint1 = new MeterPoint { Id = 1, Mpan = "123456", MpanIndicator = "1" };
            var meterPoint2 = new MeterPoint { Id = 2, Mpan = "7891234", MpanIndicator = "1" };
            meterPoint.HasData(meterPoint1);
            meterPoint.HasData(meterPoint2);

            var meter = modelbuilder.Entity<Meter>();
            meter.HasKey(p => p.Id);
            meter.HasOne<MeterPoint>(p => p.MeterPoint).WithMany(p => p.Meters).HasForeignKey(p => p.MeterPointId);
            meter.HasData(new Meter { Id = 1, MeterType = MeterType.Gas, NumberOfRegisters = 2, OperatingMode = OperatingMode.Credit, MeterPointId = 1 });
            meter.HasData(new Meter { Id = 2, MeterType = MeterType.Electric, NumberOfRegisters = 1, OperatingMode = OperatingMode.Credit, MeterPointId = 2 });


        }
    }
}
