using System.IO;
using arquivoApi.Models;

namespace arquivoApi.Interfaces 
{
    public interface IFileService
    {
        void PostMultiFileAsync(FileUploadModel fileData);
        void GetFileAsync(MemoryStream memoryStream);
    }    
}