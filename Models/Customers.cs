using System;

namespace Models
{
    public class Customers
    {
        public Customers() {}

        public Customers(string firstname) 
        {
            this.FirstName = firstname;
        }
        
        public Customers(string firstname, string lastname) 
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
        public string FirstName {get; set;}

        public string LastName {get; set;}

    }
}
