using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using MikeGrayCodes.BuildingBlocks.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser.Events
{
    public class ApplicationUserNameChangedDomainEvent : DomainEvent
    {
        public ApplicationUserNameChangedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header)
            : base(aggregateRootId, version, createdDate, header)
        {
        }

        public static ApplicationUserNameChangedDomainEvent Create(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ApplicationUserNameChangedDomainEvent domainEvent = new ApplicationUserNameChangedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null);

            return domainEvent;
        }
    }
}
