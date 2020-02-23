﻿using Microsoft.EntityFrameworkCore;
using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using MikeGrayCodes.BuildingBlocks.Domain.Events;
using System.Collections.Generic;
using System.Linq;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _meetingsContext;

        public DomainEventsAccessor(DbContext meetingsContext)
        {
            _meetingsContext = meetingsContext;
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = this._meetingsContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this._meetingsContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}