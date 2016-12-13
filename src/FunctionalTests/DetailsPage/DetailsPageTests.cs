using NUnit.Framework;
using TestHelpers;

namespace FunctionalTests.DetailsPage
{
    [TestFixture]
    public class DetailsPageTests
    {
        [Test]
        public void GivenTheHomepageWhenNavigatingToTheFilmViaTheFilmList()
        {
            SqlHelper.TruncateFilmsTable();
            SqlHelper.AddFilm("Inception", 2010);
            var homepage = BrowserContext.Site.Homepage;
            var detailsPage = BrowserContext.Site.DetailsPage;

            homepage.GoToPage();
            homepage.ClickOnFirstFilm();

            Assert.That(BrowserContext.CurrentUrl(), Is.EqualTo(detailsPage.Url("Inception", 2010)));
            Assert.That(BrowserContext.CurrentPageTitle(), Is.EqualTo("Inception (2010)"));
        }

    }
}