using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OceanStar.Argus.Authorization.Roles;
using OceanStar.Argus.Authorization.Users;
using OceanStar.Argus.MultiTenancy;

namespace OceanStar.Argus.EntityFrameworkCore
{
    public class ArgusDbContext : AbpZeroDbContext<Tenant, Role, User, ArgusDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ArgusDbContext(DbContextOptions<ArgusDbContext> options)
            : base(options)
        {
        }
    }
}
