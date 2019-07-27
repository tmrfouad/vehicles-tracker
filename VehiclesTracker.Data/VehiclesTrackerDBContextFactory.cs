using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VehiclesTracker.Data
{
    public class VehiclesTrackerDBContextFactory : IDesignTimeDbContextFactory<VehiclesTrackerDBContext>
    {
        public static IConfiguration Configuration { get; set; }
        public VehiclesTrackerDBContextFactory()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public VehiclesTrackerDBContext CreateDbContext(string[] args)
        {
            var connection = Configuration.GetConnectionString("VehiclesTrackerDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<VehiclesTrackerDBContext>();
            optionsBuilder.UseSqlServer(connection);

            return new VehiclesTrackerDBContext(optionsBuilder.Options);
        }
    }
}
