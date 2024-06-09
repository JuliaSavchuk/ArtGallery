namespace ArtGallery
{
    public class Functional
    {
        private const string DefaultFilePath = "paintings.txt";
        private string FilePath;
        public List<Painting> Paintings { get; private set; }

        public Functional()
        {
            FilePath = DefaultFilePath;
            LoadPaintings();
        }

        public void LoadPaintings()
        {
            Paintings = new List<Painting>();
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    Paintings.Add(Painting.FromString(line));
                }
            }
        }

        public void SavePaintings()
        {
            var lines = Paintings.Select(p => p.ToString()).ToArray();
            File.WriteAllLines(FilePath, lines);
        }

        public void AddPainting(Painting painting)
        {
            Paintings.Add(painting);
            SavePaintings();
        }

        public void RemovePainting(string title)
        {
            var painting = Paintings.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (painting != null)
            {
                Paintings.Remove(painting);
                SavePaintings();
            }
            else
            {
                throw new Exception("Painting not found");
            }
        }

        public List<Painting> SearchPaintings(Func<Painting, bool> predicate)
        {
            return Paintings.Where(predicate).ToList();
        }

        public void EditPainting(string title, Painting updatedPainting)
        {
            var painting = Paintings.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (painting != null)
            {
                painting.Title = updatedPainting.Title;
                painting.Year = updatedPainting.Year;
                painting.CanvasMaterial = updatedPainting.CanvasMaterial;
                painting.PaintType = updatedPainting.PaintType;
                painting.Artist = updatedPainting.Artist;
                painting.History = updatedPainting.History;
                painting.Genre = updatedPainting.Genre;
                SavePaintings();
            }
            else
            {
                throw new Exception("Painting not found");
            }
        }

        public void MoveFile(string newFilePath)
        {
            try
            {
                string newDirectory = Path.GetDirectoryName(newFilePath);
                if (!Directory.Exists(newDirectory))
                {
                    Directory.CreateDirectory(newDirectory);
                }

                File.Move(FilePath, newFilePath);
                FilePath = newFilePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error moving file: {ex.Message}");
            }
        }
    }
}
