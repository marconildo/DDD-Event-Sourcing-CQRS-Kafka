using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsAccessor<T> : IDomainEventsAccessor
        where T : DbContext
    {
        private readonly DbContext dbContext;

        public DomainEventsAccessor(T dbContext)
        {
            var hash = dbContext.GetHashCode();
            Console.WriteLine(hash);

            this.dbContext = dbContext;
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = this.dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this.dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}