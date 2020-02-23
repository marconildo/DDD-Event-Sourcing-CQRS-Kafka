using MediatR;
using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Events
{
    public interface IDomainEvent : INotification
    {
        Guid AggregateRootId { get; }
        int Version { get; }
        DateTime CreatedDate { get; }
        IHeader Header { get; }
    }
}