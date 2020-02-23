using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.Application
{
    public interface IRequestExecutor
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
