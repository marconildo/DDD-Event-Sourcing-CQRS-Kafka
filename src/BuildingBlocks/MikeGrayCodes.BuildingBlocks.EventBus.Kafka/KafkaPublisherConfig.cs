using System;
using System.Collections.Generic;
using System.Text;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaPublisherConfig
    {
        public KafkaPublisherConfig(string brokerList, string topic)
        {
            BrokerList = brokerList ?? throw new ArgumentNullException(nameof(brokerList));
            Topic = topic ?? throw new ArgumentNullException(nameof(topic));
        }

        public string BrokerList { get; private set; }
        public string Topic { get; private set; }
    }
}
