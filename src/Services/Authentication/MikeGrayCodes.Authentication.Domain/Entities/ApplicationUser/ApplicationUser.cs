using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events;
using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Rules;
using MikeGrayCodes.BuildingBlocks.Domain.Entities;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public class ApplicationUser : AggregateRoot
    {
        public string Email { get; private set; }
        public string Name { get; private set; }

        private ApplicationUser(string email, string name)
        {
            Register<ApplicationUserCreatedDomainEvent>(When);
        }

        public static ApplicationUser Create(string email, string name, IApplicationUserUniquenessChecker applicationUserUniquenessChecker)
        {
            return new ApplicationUser(email, name);
        }

        public void ChangeName(string name)
        {
            this.CheckRule(new ApplicationUserCannotChangeNameToSameRule(this.Name, name));

            this.Name = name;
        }

        public void Start()
        {
            Raise(ApplicationUserCreatedDomainEvent.Create(this));
        }

        protected void When(ApplicationUserCreatedDomainEvent @event)
        {
            Id = @event.AggregateRootId;
        }
    }
}
