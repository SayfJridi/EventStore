using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventStore
{

  
    public  class Store
    {

     
        private readonly Service _service ; 
        public  Store(Service service)
        {
           
            _service = service;
            while (true)
            {
                Console.WriteLine("Who Are u ? ");
                Console.WriteLine("1 - SalesMan");
                Console.WriteLine("2 - Inventory Manager");
                Console.WriteLine("3 - Director");
                var key = Console.ReadLine();

                if (key.Equals("1"))
                {
                    Console.WriteLine("Wait"); 
                }
                if (key.Equals("2"))
                {
                    var list = (List<Sales>)_service.getsales();
                    list.ForEach((Sales l) => Console.WriteLine(l.ToString()));
                }
                if (key.Equals("3"))
                {
                    var list = (List<Stats>)_service.getStats();
                    for(var i = 0; i<list.Count(); i++)
                    {
                        Console.WriteLine(list[i].ToString());
                    }
                }
                _service.addOrder("hello", 1, 1); 

                Console.ReadKey();
                Console.Clear(); 



            }
        }

    }
}
