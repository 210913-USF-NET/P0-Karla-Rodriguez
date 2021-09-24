using System;
using Models;
using P0BL;
using System.Collections.Generic;

namespace UI
{
    public class LoginMenu : IMenu
    {
        private IBL _bl;
        private LoginMenu(IBL bl)
        {
            _bl = bl;
            _custoService = custoService;
        }
        public void Start(){

                Console.WriteLine("Welcome back! Please enter your racer's full name to continue");
                
            } 
            private void ViewOneCustomer()
            {
                Console.WriteLine("Login");
                List<Customers> searchResult = _bl.searchCustomers(Console.ReadLine());
                if(searchResult == null || searchResult.Count == 0)
                {
                    Console.WriteLine("That racer does not exist :(");
                    return;
                }
                Customers selectedCustomer = _bl.GetOneCustomerById(selectedCustomer.Id);
                
                selectedCustomer = _bl.GetOneCustomerById(selectedCustomer.Id);
                Console.WriteLine(selectedCustomer);
                foreach(Order order in (selectedCustomer.Orders)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
}