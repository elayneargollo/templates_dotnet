using lvife.Models;
using Microsoft.AspNetCore.Mvc;
using vlife.Data;

namespace vlife.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;
        private VideoRepository _videoRepository;

        public VideoController(ILogger<VideoController> logger, VideoRepository videoRepository)
        {
            _logger = logger;
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Obter formulários
        /// </summary>
        /// <param name="page"></param>
        /// <param name="itemsByPage"></param>
        /// <param name="initialPeriod"></param>
        /// <param name="finalPeriod"></param>
        [HttpGet]
        [Route("page={page}&itemsByPage={itemsByPage}&initialPeriod={initialPeriod}&finalPeriod={finalPeriod}")]
        public async Task<ActionResult<List<Video>>> GetAllPaged(int page, int itemsByPage, 
            DateTime initialPeriod, DateTime finalPeriod)
        {
            var videosPage = _videoRepository.GetVideoFilter(page, itemsByPage,
                initialPeriod, finalPeriod);

            return Ok(videosPage);
        }
    }
}
