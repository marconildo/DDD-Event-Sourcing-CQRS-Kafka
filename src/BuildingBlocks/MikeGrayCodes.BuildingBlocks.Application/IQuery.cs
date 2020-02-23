using MediatR;
using System;

namespace MikeGrayCodes.BuildingBlocks.Application
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
