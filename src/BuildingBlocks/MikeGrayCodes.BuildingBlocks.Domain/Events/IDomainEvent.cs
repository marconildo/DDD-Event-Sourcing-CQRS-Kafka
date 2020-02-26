using MediatR;
using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Events
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}