using Microsoft.AspNetCore.Mvc;

namespace apidefault6.Controllers
{
    [ApiController]
    [Route("api/keyvault")]
    public class KeyVaultController : ControllerBase
    {
        private readonly IConfiguration _configuration;
 
        public KeyVaultController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> GetValueKey(string key)
        {
            return Ok(_configuration[key]);
        }
    }
}
