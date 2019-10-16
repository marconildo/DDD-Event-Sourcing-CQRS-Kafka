using Confluent.Kafka;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaPublisher
    {
        public readonly string brokerList;
        public readonly string topic;

        private readonly IProducer<string, string> producer;

        public KafkaPublisher(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;

            var config = new ProducerConfig { BootstrapServers = brokerList };

            producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            string data = JsonConvert.SerializeObject(domainEvent, Formatting.Indented);

            var dr = await producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = domainEvent.GetType().AssemblyQualifiedName,
                Value = data
            });
        }

        public async Task Publish(IEnumerable<DomainEvent> domainEvents, Header header)
        {
            foreach (var domainEvent in domainEvents)
            {
                domainEvent.SetHeader(header);
                await Publish(domainEvent);
            }
        }

        public void Dispose()
        {
            producer.Dispose();
        }
    }
}
