using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Skyscanner.Utils
{
    class DriverUtils
    {
        private static IWebDriver _driver;

        private static IWebDriver StartWebDriver()
        {
            IWebDriver driver = new ChromeDriver(".");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver GetDriver()
        {
            return _driver ?? (_driver = StartWebDriver());
        }
    }
}
