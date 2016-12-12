using NUnit.Framework;
using TestHelpers;

namespace FunctionalTests.HomePage
{
    [TestFixture]
    public class FilmListIsVisibleOnHomepageTests
    {
        [Test]
        public void WhenNavigatingToTheHomePageThenTheListOfFilmsIsVisible()
        {
            SqlHelper.TruncateFilmsTable();
            SqlHelper.AddFilm("Spider-Man: Homecoming", 2017);

            var homepage = BrowserContext.Site.Homepage;
            homepage.GoToPage();

            Assert.That(homepage.FirstFilmTitle(), Is.EqualTo("Spider-Man: Homecoming"));
            Assert.That(homepage.FirstFilmYear(), Is.EqualTo("2017"));
        }
    }
}