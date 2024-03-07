using System.ComponentModel.DataAnnotations.Schema;

namespace lvife.Models
{
    [Table("PROPRIETARIO_VIDEO")]
    public class VideoOwner
    {
        public long idOwnerVideo { get; set; }
        public string? name { get; set; }
        [NotMapped]
        public List<Video> videos { get; set; }
    }
}