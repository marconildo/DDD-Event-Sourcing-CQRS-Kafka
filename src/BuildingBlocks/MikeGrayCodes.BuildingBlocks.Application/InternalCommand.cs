using System;

namespace MikeGrayCodes.BuildingBlocks.Application
{
    public class InternalCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime? ProcessedDate { get; set; }
    }
}
