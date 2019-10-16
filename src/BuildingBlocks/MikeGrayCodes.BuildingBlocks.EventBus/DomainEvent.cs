﻿using System;

namespace MikeGrayCodes.BuildingBlocks.EventBus
{
    public class DomainEvent : IDomainEvent
    {
        public Guid AggregateRootId { get; private set; }
        public int Version { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Header Header { get; private set; }

        protected DomainEvent(Guid aggregateRootId, int version, DateTime createdDate, Header header)
        {
            AggregateRootId = aggregateRootId;
            Version = version;
            CreatedDate = createdDate;
            Header = header;
        }

        public static DomainEvent Create(Guid aggregateRootId, int version, DateTime createdDate)
        {
            DomainEvent domainEvent = new DomainEvent(aggregateRootId, version, createdDate, null);
            return domainEvent;
        }

        public void SetHeader(Header header)
        {
            this.Header = header;
        }
    }
}
