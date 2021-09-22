using System;
using System.Collections.Generic;

namespace Models
{
    public class Orders
    {    
        //public Orders () {
            //this.Id = 
        //} reference for a way to ID orders
        public int Id {get;}
        public List<LineItem> LineItems {get; set;}

        public decimal Totals {get; set;}
    }
}