using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehiclesTracker.Data.Configurations;
using VehiclesTracker.Data.Entities;

namespace VehiclesTracker.Data
{
    public class VehiclesTrackerDBContext : DbContext
    {
        // required for the entity framework db first (used by VehiclesTrackerDBContextFactory) 
        public VehiclesTrackerDBContext(DbContextOptions<VehiclesTrackerDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // apply custom configurations on entities
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
