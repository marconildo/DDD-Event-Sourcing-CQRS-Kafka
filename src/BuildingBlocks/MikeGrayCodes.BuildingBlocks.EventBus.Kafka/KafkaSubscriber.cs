using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaSubscriber : ISubscriber
    {
        public static readonly string AppName = Assembly.GetEntryAssembly().FullName;

        private readonly ILogger<KafkaSubscriber> logger;
        private readonly IMediator mediator;
        private readonly KafkaSubscriberConfig config;

        private static ConsumerConfig constructConfig(string brokerList, string groupId, bool enableAutoCommit) => new ConsumerConfig
        {
            GroupId = groupId,
            BootstrapServers = brokerList,
            EnableAutoCommit = enableAutoCommit,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        public KafkaSubscriber(ILogger<KafkaSubscriber> logger, IMediator mediator, KafkaSubscriberConfig config)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Listen(CancellationToken cancellationToken)
        {
            using (var c = new ConsumerBuilder<string, string>(constructConfig(config.BrokerList, config.GroupId, true)).Build())
            {
                c.Subscribe(config.Topic);
                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cancellationToken);

                            logger.LogInformation($"Topic: {cr.Topic} Partition: {cr.Partition} Offset: {cr.Offset} {cr.Value}");

                            Type eventType = Type.GetType(cr.Key);
                            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(cr.Value, eventType);

                            logger.LogInformation("----- Handling event: CorrelationId: {CorrelationId} AggregateRootId:{AggregateRoot} at {AppName} - ({@IntegrationEvent})", 
                                domainEvent.Header.CorrelationId, domainEvent.AggregateRootId, AppName, domainEvent);

                            await mediator.Send(domainEvent);

                            logger.LogInformation("----- Handled event: CorrelationId: {CorrelationId} AggregateRootId:{AggregateRoot} at {AppName} - ({@IntegrationEvent})",
                                domainEvent.Header.CorrelationId, domainEvent.AggregateRootId, AppName, domainEvent);
                        }
                        catch (ConsumeException e)
                        {
                            logger.LogError($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }
            }
        }
    }
}

