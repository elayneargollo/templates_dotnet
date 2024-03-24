using System.Collections.Generic;
using arquivoApi.Models;

namespace arquivoApi.Interfaces 
{
    public interface IBlobService
    {
        void UploadFromBinaryDataAsync(string fileName, byte[] buffer);
        List<FileDetails> DownloadStorageWithConnectionString();
    }    
}