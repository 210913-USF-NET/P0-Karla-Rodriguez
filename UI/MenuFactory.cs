using DL;
using BL;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            switch (menuString)
            {
                case "Main":
                    return new MainMenu();
                    

                    
                case "Feed":
                    return new FeedMenu(new BL(new FileRepo()));
                    
                case "Manuals 1":
                    return new ManualsIMenu(new BL(new FileRepo()));
                    
                case "Manuals 2":
                    return new ManualsIIMenu(new BL(new FileRepo()));
                default:
                    return null;
            )
        }
    }
}