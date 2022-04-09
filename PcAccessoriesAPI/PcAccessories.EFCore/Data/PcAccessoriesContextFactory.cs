using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAccessories.EFCore.Data
{
    public class PcAccessoriesContextFactory : IDesignTimeDbContextFactory<PcAccessoriesDbContext>
    {
        public PcAccessoriesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PcAccessoriesConnection");
            var severVersion = ServerVersion.AutoDetect(connectionString);


            var optionsBuilder = new DbContextOptionsBuilder<PcAccessoriesDbContext>();
            optionsBuilder.UseMySql(connectionString, severVersion);

            return new PcAccessoriesDbContext(optionsBuilder.Options);
        }
    }
}
