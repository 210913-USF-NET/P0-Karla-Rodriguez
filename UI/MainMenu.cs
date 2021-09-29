using System;
using Models;
using DL;
using P0BL;
namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            string input = "";
            do
            
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Chocobo Square!");
                Console.WriteLine("Are you a registered racer?");
                Console.WriteLine("0 - Yes");
                Console.WriteLine("1 - No");
                Console.WriteLine("x - Exit");
                
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        MenuFactory.GetMenu("items").Start();
                        break;

                    case "1":
                        MenuFactory.GetMenu("register").Start();
                        break;
                        
                    case "x":
                        Console.WriteLine("Another time then!");
                        exit = true;
                        break;
                        
                }
            } while (!exit);
        }
    }
}