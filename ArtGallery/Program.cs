namespace ArtGallery
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nWelcome to the archive of the art galery!\n");

            Menu menu = new Menu();
            menu.DisplayMenu();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Goodbye. Thank you for visiting the archive!");
        }
    }
}

