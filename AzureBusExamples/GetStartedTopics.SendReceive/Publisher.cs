using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetStartedTopics.Messages;
using Microsoft.ServiceBus.Messaging;

namespace GetStartedTopics.SendReceive
{
    public class Publisher
    {
        public static void Publish()
        {
            var connectionString = "Endpoint=sb://dn-cel-messagebus-devlocal.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=C29S/ccD2SOKT9HZzzdAuETt1x0Om25xIin6ecIbSPA=";
            var topicName = "testtopic";

            var client = TopicClient.CreateFromConnectionString(connectionString, topicName);
            Customer c = new Customer();
            c.Name = "Jacek";
            c.Age = 18;

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
