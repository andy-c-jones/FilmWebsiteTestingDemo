using NUnit.Framework;
using TestHelpers;

namespace FunctionalTests
{
    [TestFixture]
    public class AddFilmOnHomepageTests
    {
        [Test]
        public void GivenTheHomepageWhenFilmAddedViaAddControlThenTheFilmShouldBeRenderedInTheList()
        {
            SqlHelper.TruncateFilmsTable();

            var homepage = BrowserContext.Site.Homepage;

            homepage.GoToPage();
            homepage.EnterFilmNameIntoAddControl("Inception");
            homepage.EnterFilmYearIntoAddControl(2010);
            homepage.ClickAddFilm();

            Assert.That(homepage.FirstFilmTitleText(), Is.EqualTo("Inception"));
            Assert.That(homepage.FirstFilmYearText(), Is.EqualTo("2010"));
        }

        [Test]
        public void GivenTheHomepageWhenFilmAddedIsDuplicateThenTheAnErrorMessageShouldBeDisplayed()
        {
            SqlHelper.TruncateFilmsTable();

            var homepage = BrowserContext.Site.Homepage;

            homepage.GoToPage();
            homepage.EnterFilmNameIntoAddControl("Inception");
            homepage.EnterFilmYearIntoAddControl(2010);
            homepage.ClickAddFilm();
            homepage.EnterFilmNameIntoAddControl("Inception");
            homepage.EnterFilmYearIntoAddControl(2010);
            homepage.ClickAddFilm();

            Assert.That(homepage.GetDuplicateError().Contains("You already have this film on the list!"), Is.True);
        }
    }
}