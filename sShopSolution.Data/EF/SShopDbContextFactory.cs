using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sShopSolution.Data.EF
{
    public class SShopDbContextFactory : IDesignTimeDbContextFactory<SShopDbContext>
    {
        public SShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("sShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<SShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SShopDbContext(optionsBuilder.Options);
        }
    }
}
