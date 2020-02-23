using MediatR;
using MikeGrayCodes.BuildingBlocks.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T, Unit> where T : IRequest
    {
        private readonly IRequestHandler<T, Unit> decorated;
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(
            IRequestHandler<T, Unit> decorated,
            IUnitOfWork unitOfWork)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this.decorated.Handle(command, cancellationToken);

            await this.unitOfWork.Complete(cancellationToken);

            return Unit.Value;
        }
    }
}