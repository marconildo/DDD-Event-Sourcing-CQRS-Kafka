using System;

namespace MikeGrayCodes.BuildingBlocks.EventBus
{
    public class Header
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
