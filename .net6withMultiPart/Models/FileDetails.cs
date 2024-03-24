using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arquivoApi.Models
{
    [Table("fileDetails")]
    public class FileDetails : BaseEntity
    {
        [Column("fileName")]
        [Required]
        public string FileName { get; set; }
        [Column("contentType")]
        [Required]
        public string ContentType { get; set; }
        [Column("fileData")]
        [Required]
        public byte[] FileData { get; set; }       

        public FileDetails(byte[] fileData, string filename, string contenttype)
        {
            FileData = fileData;
            FileName = filename;
            ContentType = contenttype;
        }

        public FileDetails(byte[] fileData, string filename)
        {
            FileData = fileData;
            FileName = filename;
        }

        public FileDetails(){ }
    }
}