namespace ArtGallery
{
    public class Painting
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string CanvasMaterial { get; set; }
        public string PaintType { get; set; }
        public string Artist { get; set; }
        public string History { get; set; }
        public string Genre { get; set; }

        public Painting(string title, int year, string canvasMaterial, string paintType, string artist, string history, string genre)
        {
            Title = title;
            Year = year;
            CanvasMaterial = canvasMaterial;
            PaintType = paintType;
            Artist = artist;
            History = history;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title};{Year};{CanvasMaterial};{PaintType};{Artist};{History};{Genre}";
        }

        public static Painting FromString(string paintingData)
        {
            var data = paintingData.Split(';');
            return new Painting(data[0], int.Parse(data[1]), data[2], data[3], data[4], data[5], data[6]);
        }

        public string GetFormattedInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string Res = $"\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n" +
                $"Title : {Title}\nYear : {Year}\nCanvasMaterial : {CanvasMaterial}\n PaintType : {PaintType}\n" +
                $"Artist : {Artist}\n History : {History}\nGenre : {Genre}" +
                $"\n-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n";
            return Res;
        }
    }
}
