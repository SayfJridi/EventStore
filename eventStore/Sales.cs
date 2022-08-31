using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventStore
{
    public class Sales
    {

        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set;  }

        public decimal Price { get; set;  }

        public Sales(Guid id, string productName, int quantity, decimal price)
        {
            Id=id;
            ProductName=productName;
            Quantity=quantity;
            this.Price=price;
        }


        public override string ToString()
        {
            return $"------------------------------------------------------------------------------------------\x0A Id:{Id} | ProductName:{ProductName} |  Quantity:{Quantity}  | Price:{Price}";
        }
    }
}
