using Confluent.Kafka;
using System;
using System.Threading;

namespace MikeGrayCodes.BuildingBlocks.EventBus.Kafka
{
    public class KafkaSubscriber : ISubscriber
    {
        public readonly string brokerList;
        public readonly string topic;
        private readonly string groupId;

        private static ConsumerConfig constructConfig(string brokerList, string groupId, bool enableAutoCommit) => new ConsumerConfig
        {
            GroupId = groupId,
            BootstrapServers = brokerList,
            EnableAutoCommit = enableAutoCommit,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        public KafkaSubscriber(string brokerList, string topic, string groupId)
        {
            this.brokerList = brokerList ?? throw new ArgumentNullException(nameof(brokerList));
            this.topic = topic ?? throw new ArgumentNullException(nameof(topic));
            this.groupId = groupId ?? throw new ArgumentNullException(nameof(groupId));
        }

        public void Listen(CancellationToken cancellationToken)
        {
            using (var c = new ConsumerBuilder<string, string>(constructConfig(brokerList, groupId, true)).Build())
            {
                c.Subscribe(topic);
                try
                {
                    while (cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            var cr = c.Consume(cancellationToken);
                            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
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

