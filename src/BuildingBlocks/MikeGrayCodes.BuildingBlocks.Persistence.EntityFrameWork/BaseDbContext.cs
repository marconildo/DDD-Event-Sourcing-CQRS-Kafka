using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Application;
using MikeGrayCodes.BuildingBlocks.Infrastructure.Outbox;

namespace MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork
{
    public class BaseDbContext<T> : DbContext
        where T : DbContext
    {
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }



        public BaseDbContext(DbContextOptions<T> options)
            : base(options)
        {
        }
    }
}
