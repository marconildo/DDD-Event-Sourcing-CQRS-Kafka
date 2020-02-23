using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Domain
{
    public interface IUnitOfWork
    {
        Task<int> Complete(CancellationToken cancellationToken = default);
    }
}
