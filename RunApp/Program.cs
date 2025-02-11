using RunApp.Menus;

namespace RunApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppMainMenu appMainMenu = new AppMainMenu();
            appMainMenu.Run();
        }
    }
}
