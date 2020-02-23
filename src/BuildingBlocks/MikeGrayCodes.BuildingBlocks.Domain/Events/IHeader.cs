using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Events
{
    public interface IHeader
    {
        Guid CorrelationId { get; }
        string UserName { get; }
    }
}
