namespace FilmWishlist.Models
{
    public class Film
    {
        public Film(string title, int year)
        {
            Title = title;
            Year = year;
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
    }
}