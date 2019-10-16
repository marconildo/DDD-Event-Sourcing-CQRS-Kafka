using MikeGrayCodes.BuildingBlocks.Domain.Entities;
using MikeGrayCodes.BuildingBlocks.EventBus;

namespace MikeGrayCodes.BuildingBlocks.Domain.Exceptions
{
    public class TransactionConflictException : BaseException
    {
        public AggregateRoot AggregateRoot { get; private set; }
        public DomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(AggregateRoot aggregateRoot, DomainEvent domainEvent)
        {
            AggregateRoot = aggregateRoot;
            DomainEvent = domainEvent;
        }
    }
}
