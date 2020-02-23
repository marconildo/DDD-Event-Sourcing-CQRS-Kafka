using System;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.InternalCommands
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}