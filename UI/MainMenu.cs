using System;
using Models;
using DL;
using BL;
namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string input "";
            do
            //need to implement a login somewhere
            {
                Console.WriteLine("Welcome to the Chocobo Square!");
                Console.WriteLine("What items are you interested in?");
                Console.WriteLine("0 - Feed");
                Console.WriteLine("1 - Race Manual I");
                Console.WriteLine("2 - Race Manuals II");
                Console.WriteLine("x - Exit");
                
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        MenuFactory.GetMenu("Feed").Start();
                        break;

                    case "1":
                        MenuFactory.GetMenu("Manuals 1").Start();
                        break;
                    
                    case "2":
                        MenuFactory.GetMenu("Manuals 2").Start();
                        break;
                        
                    case "x":
                        Console.WriteLine("Until next time!");
                        exit = true;
                        break;
                        
                }
            } while (!exit);
        }
    }
}