using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.SeedWork
{
    public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
    {
        public T DomainEvent { get; }

        public Guid Id { get; }

        public DomainNotificationBase(T domainEvent)
        {
            this.Id = Guid.NewGuid();
            this.DomainEvent = domainEvent;
        }
    }
}