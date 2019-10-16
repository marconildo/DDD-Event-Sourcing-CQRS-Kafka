using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaPublisher
    {
        public static readonly string AppName = Assembly.GetEntryAssembly().FullName;

        private readonly ILogger<KafkaPublisher> logger;
        private readonly KafkaPublisherConfig config;

        private readonly IProducer<string, string> producer;

        public KafkaPublisher(ILogger<KafkaPublisher> logger, KafkaPublisherConfig config)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.config = config ?? throw new System.ArgumentNullException(nameof(config));

            var producerConfig = new ProducerConfig { BootstrapServers = config.BrokerList };
            producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            string data = JsonConvert.SerializeObject(domainEvent, Formatting.Indented);

            var dr = await producer.ProduceAsync(config.Topic, new Message<string, string>
            {
                Key = domainEvent.GetType().AssemblyQualifiedName,
                Value = data
            });

            logger.LogInformation("----- Published event: CorrelationId: {CorrelationId} AggregateRootId:{AggregateRoot} at {AppName} - ({@IntegrationEvent})",
                domainEvent.Header.CorrelationId, domainEvent.AggregateRootId, AppName, domainEvent);
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
