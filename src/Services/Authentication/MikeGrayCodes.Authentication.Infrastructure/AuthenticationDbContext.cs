using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork;

namespace MikeGrayCodes.Authentication.Infrastructure
{
    public class AuthenticationDbContext : BaseDbContext<AuthenticationDbContext>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
