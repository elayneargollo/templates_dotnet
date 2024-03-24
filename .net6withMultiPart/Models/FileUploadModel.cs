using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace arquivoApi.Models
{
    public class FileUploadModel
    {
        public List<IFormFile> FileData { get; set; }
    }
}