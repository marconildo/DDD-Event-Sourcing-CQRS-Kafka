using System;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Application.Behaviors
{
    public interface IInternalCommandRepository
    {
        Task<InternalCommand> GetFirstOrDefaultInternalCommand(Guid id, CancellationToken cancellationToken = default);
    }
}
