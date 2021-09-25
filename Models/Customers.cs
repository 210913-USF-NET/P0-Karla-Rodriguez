using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models;

namespace Models
{
    public class Customers
    {
        public Customers() {}

        public Customers(string firstname) 
        {
            this.FirstName = firstname;
        }
        
        public Customers(string firstname, string lastname, int customerid) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CustomerId = customerid;
            
        }

        public int CustomerId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        

                

        
        public List<Orders> Orders {get; set;}

        public override string ToString()
        {
            return $"ID: {this.CustomerId}, FirstName: {this.FirstName}, LastName: {this.LastName}";

        }
        public bool Equals(Customers customers)
        {
            return this.FirstName == customers.FirstName && this.LastName == customers.LastName && this.CustomerId == customers.CustomerId;
        }

    }
}
