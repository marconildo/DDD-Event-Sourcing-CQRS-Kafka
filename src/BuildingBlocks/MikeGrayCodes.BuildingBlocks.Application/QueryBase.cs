using System;

namespace MikeGrayCodes.BuildingBlocks.Application
{
    public abstract class QueryBase
    {
        public Guid Id { get; }

        protected QueryBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
