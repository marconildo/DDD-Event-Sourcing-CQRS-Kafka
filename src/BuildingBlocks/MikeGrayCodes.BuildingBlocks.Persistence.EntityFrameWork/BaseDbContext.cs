using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Application;
using MikeGrayCodes.BuildingBlocks.Infrastructure.Outbox;
using System;

namespace MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork
{
    public class BaseDbContext : DbContext
    {
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }



        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }
    }
}
