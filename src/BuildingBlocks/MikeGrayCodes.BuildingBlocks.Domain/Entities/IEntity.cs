using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.BuildingBlocks.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
