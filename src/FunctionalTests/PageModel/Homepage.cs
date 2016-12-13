using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FunctionalTests.PageModel
{
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
        public void ClickAddFilm() => AddFilmButton().Click();
        public void GoToPage() => _driver.Navigate().GoToUrl(Url);
        public void EnterFilmNameIntoAddControl(string name) => AddFilmTitleBox().SendKeys(name);
        public void EnterFilmYearIntoAddControl(int year) => AddFilmYearBox().SendKeys(year.ToString());

        private IWebElement AddFilmTitleBox() => FindElementByCssSelector("input[name='Title']");
        private IWebElement AddFilmYearBox() => FindElementByCssSelector("input[name='Year']");
        private IWebElement AddFilmButton() => FindElementByCssSelector("input[type='submit']");

        private string ElementText(string cssSelector) => FindElementByCssSelector(cssSelector).Text;
        private IWebElement FindElementByCssSelector(string cssSelector) => _driver.FindElementByCssSelector(cssSelector);
    }
}