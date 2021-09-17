using System;
namespace UI
{
    public class MainMenu
    {
        public void Start ()
        {
            bool exit = false;
            do

            {
                Console.WriteLine("Welcome to the Chocobo Square!");
                Console.WriteLine("Are you a registered racer?");
                Console.WriteLine("0 - Yes");
                Console.WriteLine("1 - No");
                Console.WriteLine("x - Exit");
                
                switch (Console.ReadLine())
                {
                    case "0";
                        //ManuFactorytime, but I want to ask their name first

                    case "1";
                        //Ask them to register their name onto the database
                    
                    case "x";
                        //exit message and then leave the application
                }
            }
        }
    }
}