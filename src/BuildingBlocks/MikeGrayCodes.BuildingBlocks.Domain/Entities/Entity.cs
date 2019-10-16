﻿using System;

namespace MikeGrayCodes.BuildingBlocks.Domain.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
