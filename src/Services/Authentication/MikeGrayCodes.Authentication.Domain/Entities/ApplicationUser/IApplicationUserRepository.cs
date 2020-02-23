using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public interface IApplicationUserRepository
    {
        Task Add(ApplicationUser applicationUser);
    }
}
