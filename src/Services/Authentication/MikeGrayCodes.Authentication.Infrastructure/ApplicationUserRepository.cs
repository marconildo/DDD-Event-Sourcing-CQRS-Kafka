using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser;
using System;
using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Infrastructure
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AuthenticationDbContext dbContext;

        public ApplicationUserRepository(AuthenticationDbContext dbContext)
        {
            var hash = dbContext.GetHashCode();
            Console.WriteLine(hash);
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public Task Add(ApplicationUser applicationUser)
        {
            dbContext.ApplicationUsers.Add(applicationUser);

            return Task.CompletedTask;
        }
    }
}
