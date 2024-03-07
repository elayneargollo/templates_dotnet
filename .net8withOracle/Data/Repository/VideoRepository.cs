using lvife.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace vlife.Data
{
    public class VideoRepository : GenericRepository<Video>
    {
        private readonly ILogger<VideoRepository> _logger;

        public VideoRepository(Context contexto, ILogger<VideoRepository> logger) : base(contexto)
        {
            _logger = logger;
        }

        public List<Video> GetVideoFilter(int page, int itemsByPage, DateTime initialPeriod, 
            DateTime finalPeriod)
        {
            List<Video> videos = Context.Set<Video>()
                                    .Include(v => v.videoOwner)
                                    .Where(v => v.creationDateVideo >= initialPeriod
                                                && v.creationDateVideo <= finalPeriod)
                                    .Skip((page - 1) * itemsByPage)
                                    .Take(itemsByPage)
                                    .ToList();

            _logger.LogInformation("Resultado da consulta {videos}", JsonConvert.SerializeObject(videos));
            return videos;
        }
    }
}