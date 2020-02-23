using MikeGrayCodes.BuildingBlocks.Domain.Events;
using MikeGrayCodes.BuildingBlocks.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace MikeGrayCodes.BuildingBlocks.Domain.Entities
{
    public class Entity : IEntity
    {
        private List<IDomainEvent> domainEvents;

        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => this.domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents = domainEvents ?? new List<IDomainEvent>();
            this.domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
