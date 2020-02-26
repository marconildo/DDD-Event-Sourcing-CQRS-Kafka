using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events
{
    public class ApplicationUserCreatedDomainEvent : DomainEvent
    {
        public Guid Id { get; }

        public ApplicationUserCreatedDomainEvent(Guid id)
        {
            Id = id;
        }
    }
}
