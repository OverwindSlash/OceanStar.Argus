using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OceanStar.Argus.EntityFrameworkCore
{
    public static class ArgusDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ArgusDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ArgusDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
