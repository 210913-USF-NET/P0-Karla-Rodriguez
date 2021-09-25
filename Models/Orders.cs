using System;
using System.Collections.Generic;
using System.Linq;


namespace Models
{
    public class Orders
    {    
        
        // reference for a way to ID orders
        public Orders(){}
        public Orders(int OrderId, int CustomerId)
        {
            this.OrderId = OrderId;
            this.CustomerId = CustomerId;
        }

        public int OrderId {get; set;}

        public int CustomerId{get; set;}
        public List<LineItem> LineItems {get; set;}

        public decimal Totals {get; set;}

        public override string ToString()
        {
            return $"Id: {this.OrderId}, Customer: {this.CustomerId}, Total: {this.Totals}";
        }
    }
}