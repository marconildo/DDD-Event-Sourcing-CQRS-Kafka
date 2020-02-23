namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public interface IApplicationUserUniquenessChecker
    {
        bool IsUnique(string email);
    }
}
