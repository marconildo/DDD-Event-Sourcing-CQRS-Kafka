using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Domain;
using MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork
        where T : DbContext
    {
        private readonly T context;
        private readonly IDomainEventsDispatcher domainEventsDispatcher;

        public UnitOfWork(
            T context,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            var hash = context.GetHashCode();
            Console.WriteLine(hash);

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