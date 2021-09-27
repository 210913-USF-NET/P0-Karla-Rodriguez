using System;
using Models;
using P0BL;
using System.Collections.Generic;


namespace UI
{
    public class ItemsMenu : IMenu
    {
        private IBL _bl;

        private ItemsMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start() {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Shop for items for your feathered friend!");
                Console.WriteLine("0 - See full list of products");
                Console.WriteLine("1 - I'm looking for something specific");
                Console.WriteLine("x - Go Back");

                switch(Console.ReadLine())
                {
                    case "0":
                    BrowseItems();
                    break;

                    case "1":
                    SearchForItem();
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
                Console.WriteLine("Uh oh! We'll try to restock soon!");
            }
            else
            {
                foreach (Products prods in allProds)
                {
                    Console.WriteLine(prods.ToString());
                }
            }
        }

        private void SearchForItem()
        {
            Console.WriteLine("Search for item");
            List<Products> searchResult = _bl.SearchProducts(Console.ReadLine());
            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("Couldn't find anything like that...try again!");
                return;
            }

    
        }
    }
}