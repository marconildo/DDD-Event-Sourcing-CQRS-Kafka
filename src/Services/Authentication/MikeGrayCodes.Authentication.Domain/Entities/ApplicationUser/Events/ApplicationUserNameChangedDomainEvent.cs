using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events
{
    public class ApplicationUserNameChangedDomainEvent : DomainEvent
    {
        public ApplicationUserNameChangedDomainEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
