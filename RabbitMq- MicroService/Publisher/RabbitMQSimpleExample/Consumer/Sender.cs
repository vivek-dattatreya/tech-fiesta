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
                channel.QueueDeclare("UserQueue", false, false, false, null);

                string message = @"[
  {
                    {
                        _id: '1',
               isActive: '{{bool()}}',
      picture: '',
      age: '30',
      name:
                        {
                            first: 'Test',
        last: 'RabbbitMQ'
      },
      company: 'PROFILE',
      email(tags) {
                            return `${ this.name.first}.${ this.name.last}@${ this.company}${ tags.domainZone()}`.toLowerCase();
                        },
      phone: '+1 {{phone()}}',
      address: '{{integer(100, 999)}} {{street()}}, {{city()}}, {{state()}}, {{integer(100, 10000)}}',
      about: '{{lorem(1, 'paragraphs')}}',
      registered: '{{moment(this.date(new Date(2014, 0, 1), new Date())).format('LLLL')}}',
      latitude: '{{floating(-90.000001, 90)}}',
      longitude: '{{floating(-180.000001, 180)}}',
      tags: [
                        {
                            'repeat(5)': '{{lorem(1, 'words')}}'
        }
      ],
      range: range(10)
      
]";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "UserQueue", null, body);
                Console.WriteLine("sent Following Message :" + message);


            }

            Console.WriteLine("Press [Enter] to exit the Sender App");
            Console.ReadLine();
        }
    }
}
