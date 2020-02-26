using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser;

namespace MikeGrayCodes.Authentication.Service
{
    public class ApplicationUserUniquenessChecker : IApplicationUserUniquenessChecker
    {
        public bool IsUnique(string email)
        {
            return true;
        }
    }
}
