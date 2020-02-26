using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Application.Behaviors;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Persistence.EntityFramework
{
    public class InternalCommandRepository<T> : IInternalCommandRepository
        where T : DbContext
    {
        private readonly BaseDbContext<T> dbContext;

        public InternalCommandRepository(BaseDbContext<T> dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Application.InternalCommand> GetFirstOrDefaultInternalCommand(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
