using MikeGrayCodes.BuildingBlocks.Domain;
using System;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Rules
{
    public class ApplicationUserCannotChangeNameToSameRule : IBusinessRule
    {
        private readonly string currentName;
        private readonly string newName;

        internal ApplicationUserCannotChangeNameToSameRule(string currentName, string newName)
        {
            this.currentName = currentName ?? throw new ArgumentNullException(nameof(currentName));
            this.newName = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public bool IsBroken()
        {
            return currentName != newName;
        }

        public string Message => "ApplicationUser name must not be the same as previously";
    }
}
