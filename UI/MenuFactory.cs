using DL;
using P0BL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {

            string connectionString = FileReadAllText(@"../connectionString.txt");
            DbContextOptions<P0DBContext> options = new DbContextOptionsBuilder<P0DBContext>()
            .UseSqlServer(connectionString).Options;
            P0DBContext context = new P0DBContext(options);

            switch(menuString)
            {
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(new BL(newDBRepo(context)));
                case "register":
                    return new RegisterMenu(new BL(newDBRepo(context)));
                case "location":
                    return new LocationMenu(new BL(newDBRepo(context)));
                case "items":
                    return new ItemsMenu(new BL(new DBRepo(context)));
                    default:
                    return null;
            }

        }
    }
}