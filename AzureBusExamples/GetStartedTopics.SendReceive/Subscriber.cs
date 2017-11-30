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
        public static void Subscribe(string subscription)
        {
            var connectionString = "Endpoint=sb://dn-cel-messagebus-devlocal.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=C29S/ccD2SOKT9HZzzdAuETt1x0Om25xIin6ecIbSPA=";
            var topicName = "testtopic";

            var client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, subscription, ReceiveMode.ReceiveAndDelete);

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
