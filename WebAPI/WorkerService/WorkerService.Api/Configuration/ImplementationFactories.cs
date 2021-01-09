using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceBus;
using WorkerService.Api.Services.QueueMessageService;

namespace WorkerService.Api.Configuration
{
    public static class ImplementationFactories
    {
        public static IQueueMessageService QueueMessageService(IServiceProvider serviceProvider)
        {
            var configService = serviceProvider.GetRequiredService<IConfiguration>();

            var azureServiceSettings = new AzureServiceBusSettings();
            configService.Bind("AzureServiceBus", azureServiceSettings);

            var uri = ServiceBusEnvironment.CreateServiceUri(scheme: azureServiceSettings.Scheme, serviceNamespace: azureServiceSettings.Namespace, servicePath: string.Empty);
            var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName: azureServiceSettings.AccessKeyName, sharedAccessKey: azureServiceSettings.AccessKey);
            var namespaceManager = new NamespaceManager(uri, tP);

            if (!namespaceManager.QueueExists(azureServiceSettings.QueueName))
            {
                namespaceManager.CreateQueue(azureServiceSettings.QueueName);
            }

            return new AzureServiceBusQueueMessageService(namespaceManager, azureServiceSettings.QueueName);
        }
    }
}