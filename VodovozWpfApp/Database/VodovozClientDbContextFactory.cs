using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace VodovozWpfApp.Database
{
    public class VodovozClientDbContextFactory : IDesignTimeDbContextFactory<VodovozClientDbContext>
    {
        public VodovozClientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VodovozClientDbContext>();

            optionsBuilder.UseSqlite(DI.Configuration.GetConnectionString("ClientDataBaseConnection"));

            return new VodovozClientDbContext(optionsBuilder.Options);
        }
    }
}
