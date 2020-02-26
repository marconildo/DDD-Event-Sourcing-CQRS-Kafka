using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        public DomainEvent()
        {
            this.OccurredOn = DateTime.UtcNow;
        }
    }
}