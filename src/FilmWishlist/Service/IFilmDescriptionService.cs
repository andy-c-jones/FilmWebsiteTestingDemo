namespace FilmWishlist.Service
{
    public interface IFilmDescriptionService
    {
        string Get(string title, string year);
    }
}