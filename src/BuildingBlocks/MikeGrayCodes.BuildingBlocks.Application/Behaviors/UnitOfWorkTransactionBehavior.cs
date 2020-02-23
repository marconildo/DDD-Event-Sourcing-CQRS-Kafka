using MediatR;
using Microsoft.Extensions.Logging;
using MikeGrayCodes.BuildingBlocks.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Application.Behaviors
{
    public class UnitOfWorkTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        private readonly ILogger<TRequest> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IInternalCommandRepository internalCommandRepository;

        public UnitOfWorkTransactionBehavior(ILogger<TRequest> logger, IUnitOfWork unitOfWork, IInternalCommandRepository internalCommandRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
            this.internalCommandRepository = internalCommandRepository ?? throw new ArgumentNullException(nameof(internalCommandRepository));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;

            logger.LogInformation("Begin Transaction: {Name} {@Request}", name, request);

            var response = await next();

            logger.LogInformation("Complete Transaction: {Name} {@Request}", name, request);

            if (request is InternalCommand)
            {
                var internalCommand = await internalCommandRepository.GetFirstOrDefaultInternalCommand(request.Id, cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await unitOfWork.Complete(cancellationToken);

            logger.LogInformation("Completed Transaction: {Name} {@Request}", name, request);

            return response;
        }
    }
}
