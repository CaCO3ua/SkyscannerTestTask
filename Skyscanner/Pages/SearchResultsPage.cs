using OpenQA.Selenium;
using Skyscanner.Utils;

namespace Skyscanner.Pages
{
    class SearchResultsPage
    {
        private static SearchResultsPage _instance;

        private SearchResultsPage()
        {
            _driver = DriverUtils.GetDriver();
        }

        public static SearchResultsPage GetInstance()
        {
            return _instance ?? (_instance = new SearchResultsPage());
        }

        private readonly IWebDriver _driver;

        private string spnRouteCss = "span[class='BpkText_bpk-text__JHhic BpkText_bpk-text--base__1t7aR']";
        private string spnTravellersCss = "span[class='BpkText_bpk-text__JHhic BpkText_bpk-text--sm__L7mBI SearchDetails_travellers__1mw2g']";
        private string spnCabinClassCss = "span[class='BpkText_bpk-text__JHhic BpkText_bpk-text--sm__L7mBI']";
        private string spnFlightDurationCss = "span[class='BpkText_bpk-text__2VouB BpkText_bpk-text--xs__1ycc8 Duration_duration__2Evn6']";
        private string spnFlightPriceCss = "span[class='BpkText_bpk-text__2VouB BpkText_bpk-text--lg__1PdnC BpkText_bpk-text--bold__NhE9P']";

        public string GetDepartureAirport()
        {
            var routeElements = _driver.FindElements(By.CssSelector(spnRouteCss));
            return $"{routeElements[0].Text}{routeElements[1].Text}";
        }

        public string GetDestinationAirport()
        {
            var routeElements = _driver.FindElements(By.CssSelector(spnRouteCss));
            return $"{routeElements[3].Text}{routeElements[4].Text}";
        }

        public int GetNumberOfTravellers()
        {
            var elementText = _driver.FindElement(By.CssSelector(spnTravellersCss)).Text;
            return int.Parse(elementText.Split(' ', 2)[0]);
        }

        public string GetCabinClass()
        {
            return _driver.FindElement(By.CssSelector(spnCabinClassCss)).Text;
        }

        public string GetFirstOutboundFlightTime()
        {
            return $"{_driver.FindElements(By.CssSelector(spnFlightDurationCss))[0].Text}";
        }

        public string GetFirstReturnFlightTime()
        {
            return $"{_driver.FindElements(By.CssSelector(spnFlightDurationCss))[1].Text}";
        }

        public string GetFirstFlightPrice()
        {
            return $"{_driver.FindElement(By.CssSelector(spnFlightPriceCss)).Text}";
        }
    }
}
