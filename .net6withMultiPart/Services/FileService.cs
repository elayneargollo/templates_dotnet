using System;
using System.Collections.Generic;
using System.IO;
using arquivoApi.Data.Interface;
using arquivoApi.Interfaces;
using arquivoApi.Models;
using Ionic.Zip;
using Ionic.Zlib;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace arquivoApi.Service
{
    public class FileService : IFileService
    {
        private readonly ILogger _logger;
        private readonly IFileRepository _fileRepository;

        public FileService(ILogger<FileService> logger, IFileRepository fileRepository)
        {
            _logger = logger;
            _fileRepository = fileRepository;
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

                    FileDetails fileDetails = new(buffer, fileData.FileName, fileData.ContentType);

                    _fileRepository.Add(fileDetails);
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
                using (ZipFile zip = new())
                {
                    zip.CompressionLevel = CompressionLevel.Level4;                    
                    ToFillEntryZip(zip);

                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                }  
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Excepiton : {0}", ex.Message);
                throw new Exception("An error occurred while performing the action.");
            }
        }

        protected void ToFillEntryZip(ZipFile zip)
        {
            IEnumerable<FileDetails> files = _fileRepository.GetAll().Result;

            foreach(var file in files)
            {
                Stream stream = new MemoryStream(file.FileData);
                zip.AddEntry(file.FileName, stream);
            }
        }
    }
}