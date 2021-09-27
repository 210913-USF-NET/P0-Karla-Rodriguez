using System;
using System.Collections.Generic;


namespace Models
{
    public class Products
    {
        public Products() {}

        public Products(string name, decimal price, string description, int productId)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.ProductId = productId;
        }
        public string Name {get; set;}

        public decimal Price {get; set;}
        public string Description {get; set;}

        public int ProductId {get; set;}

        public List<Inventory> Inventory {get; set;}

        public override string ToString()
        {
            return $"Name: {this.Name}, Price: {this.Price}, Description: {this.Description}, ID: {this.ProductId}";

        }
        
    }
}