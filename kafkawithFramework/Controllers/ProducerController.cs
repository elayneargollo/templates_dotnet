using Kafka.Integration.Models;
using Kafka.Integration.Services.Interface;
using System.Web.Http;

namespace Kafka.Integration.Controllers
{
    [RoutePrefix("api/producer")]
    public class ProducerController : ApiController
    {
        private readonly IProducer _producerService;

        public ProducerController(IProducer producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public string Index()
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Pessoa pessoa)
        {
            _producerService.ProduceAsync(pessoa);
            return Ok(pessoa);
        }
    }
}