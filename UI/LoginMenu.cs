using System;
using Models;
using P0BL;
using System.Collections.Generic;

namespace UI
{
    public class LoginMenu : IMenu
    {
        private IBL _bl;
        private CustomerService _custoService;
        public LoginMenu(IBL bl)
        {
            _bl = bl;
            
        }
        public void Start(){

                Console.WriteLine("Welcome back! Please enter your racer's full name to continue");

                
                
            } 
            private void ViewOneCustomer()
            {
                Console.WriteLine("Search the registry for your name");
                List<Customers> searchResult = _bl.SearchCustomers(Console.ReadLine());
                if(searchResult == null || searchResult.Count == 0)
                {
                    Console.WriteLine("That racer does not exist :(");
                    return;
                }
                
                Customers  selectedCustomer = _custoService.SelectCustomers("Enter you name", searchResult);

                selectedCustomer = _bl.GetOneCustomerById(selectedCustomer.CustomerId);
                
                selectedCustomer = _bl.GetOneCustomerById(selectedCustomer.CustomerId);
                Console.WriteLine(selectedCustomer);
                foreach(Orders order in selectedCustomer.Orders)
                {
                    Console.WriteLine(order);
                }
            }

        }
    }
