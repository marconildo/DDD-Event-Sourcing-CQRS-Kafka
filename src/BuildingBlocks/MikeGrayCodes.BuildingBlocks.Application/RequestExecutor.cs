using Autofac;
using MediatR;
using System;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Application
{
    public class RequestExecutor : IRequestExecutor
    {
        private readonly ILifetimeScope autofac;

        public RequestExecutor(ILifetimeScope autofac)
        {
            this.autofac = autofac ?? throw new ArgumentNullException(nameof(autofac));
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            using (var scope = autofac.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(command);
            }
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            using (var scope = autofac.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                await mediator.Send(command);
            }
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = autofac.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
