using System;
using System.IO;
using Azure.Storage.Blobs;
using System.Collections.Generic;
using arquivoApi.Models;
using arquivoApi.Interfaces;
using Microsoft.Extensions.Configuration;

namespace arquivoApi.Service
{
    public class BlobService : IBlobService
    {
        private readonly IConfiguration _configuration;

        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async void UploadFromBinaryDataAsync(string fileName, byte[] buffer)
        {
            try
            {
                string connectionString = _configuration["ConfigAzure:ConnectionAD"];
                string containerName = _configuration["ConfigAzure:ContainerName"];

                BlobServiceClient blobServiceClient = new(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                if(!containerClient.Exists())
                {
                    containerClient.Create();
                }

                containerClient.CreateIfNotExists();

                BlobClient blobClient = containerClient.GetBlobClient(fileName); 
                BinaryData binaryData = new(buffer);

                await blobClient.UploadAsync(binaryData, true);
            }
            catch
            {
                throw;
            }
        }

        public  List<FileDetails> DownloadStorageWithConnectionString()
        {
            try
            {
                string connectionString = _configuration["ConfigAzure:ConnectionAD"];
                string containerName = _configuration["ConfigAzure:ContainerName"];

                BlobServiceClient blobServiceClient = new(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                var blobs = containerClient.GetBlobs();
                var fileDetails = new List<FileDetails>();

                foreach (var blob in blobs)
                {
                    var blobClient = containerClient.GetBlobClient(blob.Name);
                    using var stream = new MemoryStream();

                    blobClient.DownloadTo(stream);
                    stream.Position = 0;

                    fileDetails.Add(new FileDetails(stream.ToArray(), blob.Name));
                }

                return fileDetails;
            }
            catch
            {
                throw;
            }
        }
    }
}  