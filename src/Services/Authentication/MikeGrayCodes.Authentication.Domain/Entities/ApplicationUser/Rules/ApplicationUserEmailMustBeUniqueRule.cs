using MikeGrayCodes.BuildingBlocks.Domain;
using System;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Rules
{
    public class ApplicationUserEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly IApplicationUserUniquenessChecker applicationUserUniquenessChecker;
        private readonly string email;

        internal ApplicationUserEmailMustBeUniqueRule(IApplicationUserUniquenessChecker applicationUserUniquenessChecker, string email)
        {
            this.applicationUserUniquenessChecker = applicationUserUniquenessChecker ?? throw new ArgumentNullException(nameof(applicationUserUniquenessChecker));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public bool IsBroken()
        {
            return applicationUserUniquenessChecker.IsUnique(email);
        }

        public string Message => "ApplicationUser login must be unique";
    }
}
