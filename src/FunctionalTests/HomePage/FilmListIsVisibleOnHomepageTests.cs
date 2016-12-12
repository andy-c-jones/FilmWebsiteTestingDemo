using NUnit.Framework;

namespace FunctionalTests
{
    [TestFixture]
    public class FilmListIsVisibleOnHomepageTests
    {
        [Test]
        public void WhenNavigatingToTheHomePageThenTheListOfFilmsIsVisible()
        {
            var homepage = BrowserContext.Site.Homepage;
            homepage.GoToPage();

            Assert.That(homepage.FirstFilmTitle(), Is.EqualTo("x"));
        }
    }
}