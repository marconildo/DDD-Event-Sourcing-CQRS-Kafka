using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Domain;
using MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private readonly IDomainEventsDispatcher domainEventsDispatcher;

        public UnitOfWork(
            DbContext context,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this.context = context;
            this.domainEventsDispatcher = domainEventsDispatcher;
        }


        public async Task<int> Complete(CancellationToken cancellationToken = default)
        {
            await this.domainEventsDispatcher.DispatchEventsAsync();
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}