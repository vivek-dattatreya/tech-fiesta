using RabbitMQ.Client;
using System;
using System.Text;

namespace Consumer
{
    class Sender
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicQueue", false, false, false, null);

                string message = "Getting Started with RabbitMQ Core Project";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "BasicQueue", null, body);
                Console.WriteLine("sent Following Message :" + message);


            }

            Console.WriteLine("Press [Enter] to exit the Sender App");
            Console.ReadLine();
        }
    }
}
