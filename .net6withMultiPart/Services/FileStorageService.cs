using System;
using System.Collections.Generic;
using System.IO;
using arquivoApi.Interfaces;
using arquivoApi.Models;
using Ionic.Zip;
using Ionic.Zlib;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace arquivoApi.Service
{
    public class FileStorageService : IFileService
    {
        private readonly ILogger _logger;
        private readonly IBlobService _blobService;

        public FileStorageService(IBlobService blobService, ILogger<FileService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
        }

        public void PostMultiFileAsync(FileUploadModel fileUpload)
        {
            _logger.LogInformation("Method PostMultiFileAsync in ArquivoService");

            try
            {
                List<IFormFile> filesData = fileUpload.FileData;
                
                foreach(IFormFile fileData in filesData)
                {
                    using MemoryStream stream = new();

                    fileData.CopyTo(stream);
                    byte[] buffer = stream.ToArray();

                    _blobService.UploadFromBinaryDataAsync(fileData.FileName, buffer);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Excepiton : {0}", ex.Message);
                throw new Exception("An error occurred while performing the action.");
            }
        }

        public void GetFileAsync(MemoryStream memoryStream)
        {
            _logger.LogInformation("Method GetFileAsync in ArquivoService");

            try
            {
                using ZipFile zip = new();

                zip.CompressionLevel = CompressionLevel.Level4;
                ToFillEntryZip(zip);

                zip.Save(memoryStream);
                memoryStream.Position = 0;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Excepiton : {0}", ex.Message);
                throw new Exception("An error occurred while performing the action.");
            }
        }

        protected void ToFillEntryZip(ZipFile zip)
        {
            List<FileDetails> fileDetails = 
                _blobService.DownloadStorageWithConnectionString();

            foreach(var file in fileDetails)
            {               
                Stream stream = new MemoryStream(file.FileData);
                zip.AddEntry(file.FileName, stream);
            }
        }
    }
}