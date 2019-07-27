using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Configurations
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // properties
            builder.Property(v => v.VehicleId)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(v => v.RegNo)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
