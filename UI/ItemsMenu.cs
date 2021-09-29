using System;
using Models;
using P0BL;
using System.Linq;
using System.Collections.Generic;
using   UI;


namespace UI
{
    public class ItemsMenu : IMenu
    {
        private IBL _bl;
        
        private CustomerService _custoService;

        private CustomerService _prodService;
        
        public ItemsMenu(IBL bl, CustomerService custoService, CustomerService prodService)
        {
            _bl = bl;
            _custoService = custoService;
            _prodService = prodService;
        }

        public void Start() {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Shop for items for your feathered friend!");
                Console.WriteLine("0 - Show Me Everything in the Inventory!");
                Console.WriteLine("1 - I'm Ready to Place and Order!");
                Console.WriteLine("x - Go Back");

                switch(Console.ReadLine())
                {
                    case "0":
                    BrowseItems();
                    break;
                    case "1":
                    AddOrder();
                    break;
                    case "x":
                    exit = true;
                    break;
                }
            } while(!exit);
        }

        private void BrowseItems ()
        {
            List<Products> allProds = _bl.GetAllProducts();
            if(allProds.Count == 0)
            {
                Console.WriteLine("Uh oh! Looks like we sold out of everything!");
            }
            else
            {
                foreach (Products prods in allProds)
                {
                    Console.WriteLine(prods.ToString());                  
                }
            } Console.WriteLine("Hit Enter To Return To The Menu");
            Console.ReadLine();
        }
        private void AddOrder()
        {
            Console.WriteLine("Search the registry for your first name!");
            List<Customers> searchResult = _bl.SearchCustomers(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No matching name : (");
                Console.ReadLine();
                return;
            }
            Customers selectedCustomer = _custoService.SelectCustomers("Enter", searchResult);
            Console.WriteLine($"Hello {selectedCustomer.FirstName}! ");
            
        
            Console.WriteLine("Please enter the item: ");

            List<Products> searchResultProd = _bl.SearchProducts(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("Couldn't find anything like that...try again!");
                return;
            }
            
            Products selectedProducts  = _prodService.SelectAProduct ("You're ready for checkout!!", searchResultProd);
            
            
            Orders orderToAdd = new Orders();
            orderToAdd.CustomerId = selectedCustomer.CustomerId;
            orderToAdd.ProductId = selectedProducts.ProductId;

            order:
            int userOrder;
            bool success = int.TryParse(Console.ReadLine(), out userOrder);
            if(!success) 
            {
            
            }
            try
            {
                
                orderToAdd.OrderId = userOrder;
            }
            catch (InputInvalidException e)
            {
                
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid input");
                goto order;
            }
            finally
            {
                Orders addedOrder = _bl.AddOrder(orderToAdd);
                Console.WriteLine("Order Processed successfully");
                Console.WriteLine(addedOrder);
                Console.ReadLine();
            }
        }
    }
}