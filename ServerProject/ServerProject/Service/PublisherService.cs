using ClientProject.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.Service
{
    public class PublisherService : IPublisherService
    {

        private const string ServiceBusPrimaryConnectionString = "Endpoint=sb://projetofinal2.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3kYXJtRoXF9lXKXJBk4TIpCoJeeVVocNe65EY89l5dM=";
        private const string TopicName = "squids-info";
        private static ITopicClient _topicClient;

        public PublisherService()
        {
            _topicClient = new TopicClient(ServiceBusPrimaryConnectionString, TopicName);
        }

        public async Task Send(DataTransfer data)
        {
            var message = ToMessage(data);

            try
            {
                await _topicClient.SendAsync(message);
            } catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                await _topicClient.CloseAsync();
            }
        }

        public static Message ToMessage(DataTransfer data)
        {

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            var message = new Message
            {
                Body = body,
                ContentType = "text/plain",
            };

            return message;
        }
    }
}
