using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Events
{
    public class Header : IHeader
    {
        public Guid CorrelationId { get; private set; }
        public string UserName { get; private set; }

        public Header(Guid correlationId, string userName)
        {
            CorrelationId = correlationId;
            UserName = userName;
        }
    }
}
