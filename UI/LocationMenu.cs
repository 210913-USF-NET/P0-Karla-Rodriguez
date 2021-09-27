using System;
using Models;
using P0BL;
using System.Collections.Generic;

namespace UI
{
    public class LocationMenu :IMenu
    {
        private IBL _bl;

        public LocationMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start(){
            bool exit = false;
            do 
            {
                Console.Clear();
                Console.WriteLine("Select a Location");
                Console.WriteLine("0 - option 1");
                Console.WriteLine("1 - option 2");
                Console.WriteLine("2 - option 3");
                Console.WriteLine("x - Go Back");

                switch(Console.ReadLine())
                {
                    case "0":
                    //option
                    break;
                    case "1":
                    //option
                    break;
                    case "2":
                    //option
                    break;
                    case "3":
                    //option
                    break;
                    case "x":
                    exit = true;
                    break;

                }
            }while (!exit);
        }
    }
}