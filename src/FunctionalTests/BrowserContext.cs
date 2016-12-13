using System;
using FunctionalTests.PageModel;
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
}