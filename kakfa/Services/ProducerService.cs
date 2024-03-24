using Confluent.Kafka;
using Kafka.Integration.Models;
using Kafka.Integration.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Kafka.Integration.Services
{
    public class ProducerService : IProducer
    {
        public ProducerService()
        {

        }

        public async Task ProduceAsync(Pessoa pessoa)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            var topic = "person";

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    string pessoaConvert = JsonConvert.SerializeObject(pessoa);
                    var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = pessoaConvert });

                    Console.WriteLine($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}