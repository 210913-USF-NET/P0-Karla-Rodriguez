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
                    
                case "Purchase Items":
                    return new ItemsMenu();
                    
                case "Feed":
                    return new FeedMenu();
                    
                case "Manuals 1":
                    return new ManualsIMenu();
                    
                case "Manuals 2":
                    return new ManualsIIMenu();
                default:
                    return null;
            )
        }
    }
}