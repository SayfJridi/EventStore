using EventStore.Client;
using EventStore.ClientAPI;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EventData = EventStore.Client.EventData;

namespace eventStore
{
    public class Service
    {
        public static EventStoreClientSettings settings = EventStoreClientSettings
.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        EventStoreClient client = new EventStoreClient(settings);
        public List<Sales> _sales = new List<Sales>(); 
   

            public async void addOrder(string ProductName , int Quantity  , decimal Price)
        {
            var sale = new Sales(Guid.NewGuid(),ProductName,Quantity, Price);
            var eventData = new EventData(
                Uuid.NewUuid(),
                "some-event",
                Encoding.UTF8.GetBytes("{\"id\": \"1\" \"value\": \"some value\"}")
            );
            await client.AppendToStreamAsync(
    "some-stream",
    StreamState.NoStream,
    new List<EventData> {
        eventData
    });
        }
        public List<Sales> getsales()
        {
            return _sales;
        }
        public  List<Stats> getStats() {

            var statlist = _sales.GroupBy(info => info.ProductName)
                       .Select(group  => new Stats(group.Key, group.Count()))
                       .OrderBy(x => x.ProductName).ToList() ;

        
            
                Console.WriteLine(value: $"{statlist[0].ProductName} + {statlist[0].QuanitiesSold}"); 
            

            return new List<Stats>()  ;
           
        }
        
       

    }
}
