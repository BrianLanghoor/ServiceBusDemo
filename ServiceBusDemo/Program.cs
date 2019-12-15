using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessageToQueue().GetAwaiter().GetResult();
        }

        private static async Task SendMessageToQueue()
        {
            var queueClient = new QueueClient("<<<SAS ServiceBus connection string>>>", "<<<Queue name>>>");
            Console.WriteLine("This is the publisher");
            while (true)
            {
                Console.WriteLine("Write the message to send");
                var message = Console.ReadLine();

                if (message == "exit")
                {
                    Console.WriteLine("Stopping publisher");
                    break;
                }

                var body = new Message(Encoding.UTF8.GetBytes(message));
                Console.WriteLine($"Sending message");
                await queueClient.SendAsync(body);
            }
        }
    }
}
