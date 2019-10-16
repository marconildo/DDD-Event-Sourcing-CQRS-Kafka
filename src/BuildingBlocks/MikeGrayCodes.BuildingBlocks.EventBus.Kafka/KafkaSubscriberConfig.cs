using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaSubscriberConfig
    {
        public KafkaSubscriberConfig(string brokerList, string topic, string groupId)
        {
            BrokerList = brokerList ?? throw new ArgumentNullException(nameof(brokerList));
            Topic = topic ?? throw new ArgumentNullException(nameof(topic));
            GroupId = groupId ?? throw new ArgumentNullException(nameof(groupId));
        }

        public string BrokerList { get; private set; }
        public string Topic { get; private set; }
        public string GroupId { get; private set; }
    }
}
