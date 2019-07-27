using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(250);

            // relations
            builder.HasMany(c => c.Vehicles)
                .WithOne(v => v.Customer)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
