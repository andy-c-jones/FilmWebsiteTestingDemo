using OpenQA.Selenium.Chrome;

namespace FunctionalTests.PageModel
{
    public class FilmWishlistSite
    {
        public readonly Homepage Homepage;
        public readonly DetailsPage DetailsPage;

        public FilmWishlistSite(ChromeDriver driver, string baseUrl)
        {
            Homepage = new Homepage(driver, baseUrl);
            DetailsPage = new DetailsPage(driver, baseUrl);
        }
    }
}