using ClientProject.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProject.Service
{
    public static class SubscriberService
    {
        private const string ServiceBusPrimaryConnectionString = "Endpoint=sb://projetofinal2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3kYXJtRoXF9lXKXJBk4TIpCoJeeVVocNe65EY89l5dM=";
        private const string TopicName = "squids-info";
        private const string SubscriptionName = "process-info";
        private static ISubscriptionClient _subscriptionClient;

        public static async Task Run()
        {
            _subscriptionClient = new SubscriptionClient(ServiceBusPrimaryConnectionString,
                TopicName,
                SubscriptionName);

            RegisterAndReceiveMessages();

            Console.ReadKey();

            await _subscriptionClient.CloseAsync();
        }
        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encounteredd an exception {exceptionReceivedEventArgs.Exception}.");

            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");

            return Task.CompletedTask;
        }

        private static async Task ProcessReceivedMessages(Message message, CancellationToken token)
        {
            DataTransfer data = FromMessage(message);

            Console.WriteLine("send Data transfer");

            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static void RegisterAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessReceivedMessages, messageHandlerOptions);
        }

        private static DataTransfer FromMessage(Message message)
        {
            var model = JsonConvert.DeserializeObject<DataTransfer>(Encoding.UTF8.GetString(message.Body));

            return model;
        }
    }
}
