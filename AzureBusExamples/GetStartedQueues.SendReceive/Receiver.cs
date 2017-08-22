using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetStartedQueues.Messages;
using Microsoft.ServiceBus.Messaging;

namespace GetStartedQueues.SendReceive
{
    public class Receiver
    {
        public static void Receive()
        {
            var connectionString = "Endpoint=sb://jacekkowalskinamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RDmx5s0pawsxnu0o8W0ws2N7K4D3jZkmwus5Np7haZM=";
            var queueName = "firstqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            string customerType = typeof(Customer).ToString();
            string storeType = typeof(Store).ToString(); ;

            client.OnMessage(message =>
            {
                //Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));

                if (message.ContentType == customerType)
                {
                    Customer cust = message.GetBody<Customer>();
                    Debug.WriteLine(String.Format("Name: {0}, Age: {1}", cust.Name, cust.Age));
                    Debug.WriteLine(String.Format("Message id: {0}", message.MessageId));
                }
                else if (message.ContentType == storeType)
                {
                    Store store = message.GetBody<Store>();
                    Debug.WriteLine(string.Format("Name: {0}, Address: {1}", store.Name, store.Address));
                    Debug.WriteLine(String.Format("Message id: {0}", message.MessageId));
                }
                else
                {
                    throw new Exception(message.ContentType);
                }
            });
        }
    }
}
