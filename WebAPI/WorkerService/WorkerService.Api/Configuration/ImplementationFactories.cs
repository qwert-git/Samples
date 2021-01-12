using System;
using Azure.Storage.Blobs;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkerService.Core.Services.FileStorageService;
using WorkerService.Core.Services.QueueMessageService;

namespace WorkerService.Api.Configuration
{
    public static class ImplementationFactories
    {
        public static IQueueMessageService QueueMessageService(IServiceProvider serviceProvider)
        {
            var settings = GetSettings<AzureServiceBusSettings>(serviceProvider, "AzureServiceBus");

            var queue = new QueueClient(settings.ConnectionString, settings.QueueName);

            return new AzureServiceBusQueueMessageService(queue);
        }

        public static IFileStorageService FileStorageService(IServiceProvider serviceProvider)
        {
            var configService = serviceProvider.GetRequiredService<IConfiguration>();
            var blobStorageSettings = GetSettings<AzureBlobStorageSettings>(serviceProvider, "AzureBlobStorage");

            var blobServiceClient = new BlobServiceClient(blobStorageSettings.ConnectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(blobStorageSettings.ContainerName);

            return new AzureBlobFileStorageService(blobContainerClient);
        }

        private static T GetSettings<T>(IServiceProvider serviceProvider, string sectionName) where T : new()
        {
            var configService = serviceProvider.GetRequiredService<IConfiguration>();
            return configService.GetSection(sectionName).Get<T>();
        }
    }
}