using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events;
using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser
{
    public class ApplicationUser : AggregateRoot
    {
        private ApplicationUser()
        {
            Register<ApplicationUserCreatedDomainEvent>(When);
        }

        public static ApplicationUser Create()
        {
            return new ApplicationUser();
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
