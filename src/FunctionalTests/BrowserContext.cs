using System;
using NUnit.Framework.Constraints;
using OpenQA.Selenium.Chrome;

namespace FunctionalTests
{
    public static class BrowserContext
    {
        public static ChromeDriver Driver { get; private set; }
        public static FilmWishlistSite Site { get; private set; }

        public static void Start()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Site = new FilmWishlistSite(Driver, "http://localhost:44342/");
        }

        public static void Stop()
        {
            Driver.Dispose();
        }
    }

    public class FilmWishlistSite
    {
        public readonly Homepage Homepage;

        public FilmWishlistSite(ChromeDriver driver, string baseUrl)
        {
            Homepage = new Homepage(driver, baseUrl);
        }


    }

    public class Homepage
    {
        private readonly ChromeDriver _driver;
        public string Url { get; }

        public Homepage(ChromeDriver driver, string baseUrl)
        {
            _driver = driver;
            Url = baseUrl;
        }

        public string FirstFilmTitle() => ElementText("tbody tr td");
        public string FirstFilmYear() => ElementText("tbody tr td:nth-child(2)");

        public void GoToPage() => _driver.Navigate().GoToUrl(Url);

        private string ElementText(string cssSelector) => _driver.FindElementByCssSelector(cssSelector).Text;

        public void EnterFilmNameIntoAddControl(string testfilm)
        {
        }

        public void EnterFilmYearIntoAddControl(int i)
        {
        }

        public void ClickAddFilm()
        {
            throw new NotImplementedException();
        }
    }
}