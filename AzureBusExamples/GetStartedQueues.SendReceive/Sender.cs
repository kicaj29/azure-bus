using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetStartedQueues.Messages;
using Microsoft.ServiceBus.Messaging;

namespace GetStartedQueues.SendReceive
{
    public class Sender
    {
        public static void Send()
        {
            var connectionString = "Endpoint=sb://jacekkowalskinamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RDmx5s0pawsxnu0o8W0ws2N7K4D3jZkmwus5Np7haZM=";
            var queueName = "firstqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            Customer c = new Customer();
            c.Name = "Jacek";
            c.Age = 18;

            //var message = new BrokeredMessage("This is a test message!");
            var message = new BrokeredMessage(c);
            message.ContentType = typeof(Customer).ToString();
            client.Send(message);

            var store = new Store();
            store.Name = "My store";
            store.Address = "Address";

            var message1 = new BrokeredMessage(store);
            message1.ContentType = typeof(Store).ToString();
            client.Send(message1);
        }
    }
}
