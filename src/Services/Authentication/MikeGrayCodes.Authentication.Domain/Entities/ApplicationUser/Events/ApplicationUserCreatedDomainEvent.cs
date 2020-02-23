using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events
{
    public class ApplicationUserCreatedDomainEvent : DomainEvent
    {
        public ApplicationUserCreatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static ApplicationUserCreatedDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ApplicationUserCreatedDomainEvent domainEvent = new ApplicationUserCreatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
