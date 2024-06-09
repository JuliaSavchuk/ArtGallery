namespace ArtGallery
{
    public class Menu
    {
        private Functional functional;

        public Menu()
        {
            functional = new Functional();
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                Console.WriteLine("1. Add Painting\n2. Remove Painting\n3. Search Painting\n4. Edit Painting\n5. Move Painting File\n6. Exit");
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                Console.WriteLine("Your choice ");

                var choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        AddPainting();
                        EnterPlease();
                        break;
                    case "2":
                        RemovePainting();
                        EnterPlease();
                        break;
                    case "3":
                        SearchPaintings();
                        EnterPlease();
                        break;
                    case "4":
                        EditPainting();
                        EnterPlease();
                        break;
                    case "5":
                        MoveFile();
                        EnterPlease();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public void AddPainting()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            try
            {
                Console.Write("Enter title: ");
                var title = Console.ReadLine();
                Console.Write("Enter year: ");
                var year = int.Parse(Console.ReadLine());
                Console.Write("Enter canvas material: ");
                var canvasMaterial = Console.ReadLine();
                Console.Write("Enter paint type: ");
                var paintType = Console.ReadLine();
                Console.Write("Enter artist: ");
                var artist = Console.ReadLine();
                Console.Write("Enter history: ");
                var history = Console.ReadLine();
                Console.Write("Enter genre: ");
                var genre = Console.ReadLine();
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

                var painting = new Painting(title, year, canvasMaterial, paintType, artist, history, genre);
                functional.AddPainting(painting);
                Console.WriteLine("Painting added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding painting: {ex.Message}");
            }
        }

        public void RemovePainting()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            try
            {
                Console.Write("Enter title of the painting to remove: ");
                var title = Console.ReadLine();
                functional.RemovePainting(title);
                Console.WriteLine("Painting removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing painting: {ex.Message}");
            }
        }

        private void SearchPaintings()
        {
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("1. By Title\n2. By Artist\n3. By Year\n4. By Genre");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("Your choice -> ");
            var choice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.Write("Enter search query: ");
            var query = Console.ReadLine();

            List<Painting> results = null;

            switch (choice)
            {
                case "1":
                    results = functional.SearchPaintings(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
                    break;
                case "2":
                    results = functional.SearchPaintings(p => p.Artist.Contains(query, StringComparison.OrdinalIgnoreCase));
                    break;
                case "3":
                    results = functional.SearchPaintings(p => p.Year.ToString().Contains(query));
                    break;
                case "4":
                    results = functional.SearchPaintings(p => p.Genre.Contains(query, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    return;
            }

            if (results != null && results.Count > 0)
            {
                Console.WriteLine("Found paintings:");
                foreach (var painting in results)
                {
                    Console.WriteLine(painting.GetFormattedInfo());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No paintings found.");
            }
        }

        public void EditPainting()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            try
            {
                Console.Write("Enter title of the painting to edit: ");
                var title = Console.ReadLine();
                Console.Write("Enter new title: ");
                var newTitle = Console.ReadLine();
                Console.Write("Enter new year: ");
                var newYear = int.Parse(Console.ReadLine());
                Console.Write("Enter new canvas material: ");
                var newCanvasMaterial = Console.ReadLine();
                Console.Write("Enter new paint type: ");
                var newPaintType = Console.ReadLine();
                Console.Write("Enter new artist: ");
                var newArtist = Console.ReadLine();
                Console.Write("Enter new history: ");
                var newHistory = Console.ReadLine();
                Console.Write("Enter new genre: ");
                var newGenre = Console.ReadLine();
                Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

                var updatedPainting = new Painting(newTitle, newYear, newCanvasMaterial, newPaintType, newArtist, newHistory, newGenre);
                functional.EditPainting(title, updatedPainting);
                Console.WriteLine("Painting edited successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error editing painting: {ex.Message}");
            }
        }

        private void MoveFile()
        {
            try
            {
                Console.Write("Enter new file path (including file name): ");
                var newFilePath = Console.ReadLine();
                functional.MoveFile(newFilePath);
                Console.WriteLine("File moved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving file: {ex.Message}");
            }
        }

        public void EnterPlease()
        {

            Console.WriteLine("Press 'Enter' To continue ");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
