using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetStartedTopics.Messages;
using Microsoft.ServiceBus.Messaging;

namespace GetStartedTopics.SendReceive
{
    public class Subscriber
    {
        public static void Subscribe()
        {
            var connectionString = "Endpoint=sb://jacekkowalski1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HMbCAwsNnSu9KJId5TuHz8jzbzgbMzpSD4tJfABT2EE=";
            var queueName = "firsttopic";

            var client = SubscriptionClient.CreateFromConnectionString(connectionString, queueName, "subscription1");

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
