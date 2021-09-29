using System;
using Models;
using P0BL;
using System.Collections.Generic;


namespace UI
{
    public class RegisterMenu : IMenu
    {
        private IBL _bl;
        public RegisterMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start() {
        bool exit = false;
        do
        {
            
            Console.Clear();
            Console.WriteLine("Ready to hit the race track?");
            Console.WriteLine("0 - Register today!");
            Console.WriteLine("x - Go Back");

            switch(Console.ReadLine())
            {
                case "0":
                CreateCustomer();
                break;
                
                case "x":
                exit = true;
                break;
            }
        } while (!exit);
    }
        private void CreateCustomer()
        {
            Console.WriteLine("Registering new racer");
            Customers newCusto = new Customers();
            inputFirstName:
            Console.WriteLine("First Name:");
            string firstname = Console.ReadLine();
            try
            {
                newCusto.FirstName = firstname;
            }
            catch (InputInvalidException e)
            {
                Console.WriteLine(e.Message);
                goto inputFirstName;
            }
            Console.WriteLine("Last Name:");
            newCusto.LastName = Console.ReadLine();

            Customers addedCusto = _bl.AddCustomers(newCusto);
            Console.WriteLine($"{addedCusto} is all set!");
        }
        
    }
}