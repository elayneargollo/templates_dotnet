namespace lvife.Models
{
    public class Video
    {
        public long idVideo { get; set; }
        public string? videoName { get; set; }
        public DateTime? creationDateVideo { get; set; }
        public long? duration { get; set; }
        public string? storedLocation { get; set; }
        public string? oldPublicLink { get; set; }
        public string? currentPublicLink { get; set; }
        public bool? publicVideo { get; set; }
        public bool? possuiThumb { get; set; }
        public bool? corruptedVideo { get; set; }
        public bool? videoNotFound { get; set; }
        public VideoOwner videoOwner { get; set; }
        public long idOwnerVideo { get; set; }
    }
}