﻿using NUnit.Framework;
using TestHelpers;

namespace FunctionalTests.DetailsPage
{
    [TestFixture]
    public class DetailsPageTests
    {
        private const string _inceptionPlot = "Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb's rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible - inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming.";

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
            Assert.That(BrowserContext.PageHtmlContains(_inceptionPlot), Is.True);
        }
    }
}