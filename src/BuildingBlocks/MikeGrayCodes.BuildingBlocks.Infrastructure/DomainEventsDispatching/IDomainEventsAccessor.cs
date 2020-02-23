using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System.Collections.Generic;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}