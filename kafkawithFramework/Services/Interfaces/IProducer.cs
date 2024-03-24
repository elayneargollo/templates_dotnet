using Kafka.Integration.Models;
using System.Threading.Tasks;

namespace Kafka.Integration.Services.Interface
{
    public interface IProducer
    {
        Task ProduceAsync(Pessoa pessoa);
    }
}