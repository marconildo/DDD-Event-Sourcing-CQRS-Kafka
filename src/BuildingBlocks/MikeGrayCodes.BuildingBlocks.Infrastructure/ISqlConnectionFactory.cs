using System.Data;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}