using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OceanStar.Argus.Configuration;
using OceanStar.Argus.Web;

namespace OceanStar.Argus.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ArgusDbContextFactory : IDesignTimeDbContextFactory<ArgusDbContext>
    {
        public ArgusDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ArgusDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ArgusDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ArgusConsts.ConnectionStringName));

            return new ArgusDbContext(builder.Options);
        }
    }
}
