using DL;
using P0BL;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            switch(menuString)
            {
                case "main":
                    return new MainMenu();
                    default:
                    return null;
            }

        }
    }
}