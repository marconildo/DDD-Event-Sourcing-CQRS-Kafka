using System;

namespace MikeGrayCodes.BuildingBlocks.Application.Behaviors
{
    public interface IOutboxMessage
    {
        Guid Id { get; set; }

        DateTime OccurredOn { get; set; }

        string Type { get; set; }

        string Data { get; set; }

        DateTime? ProcessedDate { get; set; }
    }
}
