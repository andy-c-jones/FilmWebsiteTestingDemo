using OpenQA.Selenium.Chrome;

namespace FunctionalTests.PageModel
{
    public class DetailsPage
    {
        private readonly ChromeDriver _driver;
        private readonly string _baseUrl;

        public DetailsPage(ChromeDriver driver, string baseUrl)
        {
            _driver = driver;
            _baseUrl = baseUrl;
        }

        public string Url(string title, int year) => $"{_baseUrl}films/{title}-{year}/details";
    }
}