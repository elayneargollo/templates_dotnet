using arquivoApi.Data.Interface;
using arquivoApi.Data.Repository;
using arquivoApi.Interfaces;
using arquivoApi.Service;
using Microsoft.Extensions.DependencyInjection;

namespace arquivoApi.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection DependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IFileRepository, FileDetailsRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileService, FileStorageService>();
            services.AddScoped<IBlobService, BlobService>();

            return services;
        }
    }
}