using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Application.Behaviors
{
    public interface IInternalCommandRepository
    {
        Task<InternalCommand> GetFirstOrDefaultInternalCommand(Guid id, CancellationToken cancellationToken = default);
    }
}
