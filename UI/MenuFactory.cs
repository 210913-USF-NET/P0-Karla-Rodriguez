using DL;
using P0BL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;


namespace UI
{
    public class MenuFactory
    {
        
        public static IMenu GetMenu(string menuString)
        {

            string connectionString = File.ReadAllText(@"../connectionString.txt");
            
            DbContextOptions<P0DBContext> options = new DbContextOptionsBuilder<P0DBContext>()
            .UseSqlServer(connectionString).Options;
            P0DBContext context = new P0DBContext(options);

            switch(menuString)
            {
                case "main":
                    return new MainMenu();
                case "register":
                    return new RegisterMenu(new BL(new DBRepo(context)));
                case "location":
                    return new LocationMenu(new BL(new DBRepo(context)));
                case "items":
                    return new ItemsMenu(new BL(new DBRepo(context)), new CustomerService(), new CustomerService());
                    default:
                    return null;
                    
            
            }

        }
    }
}