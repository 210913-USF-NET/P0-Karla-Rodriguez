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
        public LoginMenu(IBL bl, CustomerService custoService)
        {
            _bl = bl;
            _custoService = custoService;
            
        }
        public void Start(){
            bool exit = false;
            do
            {
                //Console.Clear();
                Console.WriteLine("Welcome back! Please enter your racer's full name to continue");
                Console.WriteLine("0 - Enter Information");
                Console.WriteLine("x - Go Back");
                
                switch(Console.ReadLine())
                {
                    case "0":
                    ViewOneCustomer();
                    break;

                    case "x":
                    exit = true;
                    break;
                }
            } while(!exit);
                

                
                
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
