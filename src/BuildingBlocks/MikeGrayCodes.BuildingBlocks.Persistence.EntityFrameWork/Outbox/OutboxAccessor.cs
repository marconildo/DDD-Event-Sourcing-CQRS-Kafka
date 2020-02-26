using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Infrastructure.Outbox;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork;

namespace MikeGrayCodes.BuildingBlocks.Persistence.EntityFramework.Outbox
{
    public class OutboxAccessor<T> : IOutbox
        where T : DbContext
    {
        private readonly BaseDbContext<T> dbContext;

        public OutboxAccessor(BaseDbContext<T> context)
        {
            dbContext = context;
        }

        public void Add(OutboxMessage message)
        {
            dbContext.OutboxMessages.Add(message);
        }
    }
}
