using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Application;
using MikeGrayCodes.BuildingBlocks.Application.Behaviors;
using MikeGrayCodes.BuildingBlocks.Infrastructure.InternalCommands;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Persistence.EntityFramework
{
    public class InternalCommandRepository : IInternalCommandRepository
    {
        private readonly BaseDbContext dbContext;

        public InternalCommandRepository(BaseDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Application.InternalCommand> GetFirstOrDefaultInternalCommand(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
