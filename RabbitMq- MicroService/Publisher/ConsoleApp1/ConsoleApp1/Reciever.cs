﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace ConsoleApp1
{
    class Reciever
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicQueue", false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Recieved Following Message {0}:", message);
                };

                channel.BasicConsume("BasicQueue", true, consumer);


                Console.WriteLine("Press [Enter] to exit the Reciever App");
                Console.ReadLine();
            }
        }
    }
}
