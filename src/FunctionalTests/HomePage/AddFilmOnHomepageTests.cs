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

            Assert.That(homepage.FirstFilmTitle(), Is.EqualTo("Inception"));
            Assert.That(homepage.FirstFilmYear(), Is.EqualTo("2010"));
        }
    }
}