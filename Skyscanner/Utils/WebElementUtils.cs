using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Skyscanner.Utils
{
    public static class WebElementUtils
    {
        static readonly IWebDriver Driver;

        static WebElementUtils()
        {
            Driver = DriverUtils.GetDriver();
        }

        public static IWebElement ClickEx(this IWebElement element)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(element)).Click();
            return element;
        }
    }
}
