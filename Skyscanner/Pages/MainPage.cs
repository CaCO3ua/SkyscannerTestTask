using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Skyscanner.Utils;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Skyscanner.Pages
{
    class MainPage
    {
        private readonly IWebDriver _driver;
        private string hlkSkyscannerNetXpath = "//a[@class='BpkLink_bpk-link__1pxbY' and text()[contains(.,'skyscanner.net')]]";
        private string btnAcceptCookieId = "acceptCookieButton";
        private string rdoReturnXPath = "//span[text()[contains(.,'Return')]]";
        private string rdoOneWayId = "fsc-trip-type-selector-one-way";
        private string txtFromId = "fsc-origin-search";
        private string txtToId = "fsc-destination-search";
        private string btnDepartId = "depart-fsc-datepicker-button";
        private string ddlDepartMonthId = "depart-calendar__bpk_calendar_nav_select";
        private string btnReturnId = "return-fsc-datepicker-button";
        private string ddlReturnMonthId = "return-calendar__bpk_calendar_nav_select";
        private string btnDayCss = "button[aria-label$='{0}']";
        private string btnCabinClassId = "CabinClassTravellersSelector_fsc-class-travellers-trigger__LeM38";
        private string ddlCabinClassId = "search-controls-cabin-class-dropdown";
        private string btnAddAdultsCss = "button[title='Increase number of adults']";
        private string btnAddChildrenCss = "button[title='Increase number of children']";
        private string ddlChildAgeId = "children-age-dropdown-{0}";
        private string btnDoneXpath = "//button[text()[contains(.,'Done')]]";
        private string btnSearchFlightsCss = "button[aria-label='Search flights']";

        private static MainPage _instance;

        private MainPage()
        {
            _driver = DriverUtils.GetDriver();
        }

        public static MainPage GetInstance()
        {
            return _instance ?? (_instance = new MainPage());
        }

        public MainPage GoToSkyskannerNet()
        {
            if (_driver.FindElements(By.XPath(hlkSkyscannerNetXpath)).Count != 0)
                _driver.FindElement(By.XPath(hlkSkyscannerNetXpath)).ClickEx();
            return GetInstance();
        }

        public MainPage AcceptCookieWarning()
        {
            _driver.FindElement(By.Id(btnAcceptCookieId)).ClickEx();
            return GetInstance();
        }

        public MainPage ToggleSearchType(bool isReturn)
        {
            if (isReturn)
            {
                _driver.FindElement(By.XPath(rdoReturnXPath)).ClickEx();
            }
            else
            {
                _driver.FindElement(By.Id(rdoOneWayId)).ClickEx();
            }
            return GetInstance();
        }

        public MainPage EnterDepartureAirport(string departureAirport)
        {
            _driver.FindElement(By.Id(txtFromId)).SendKeys(departureAirport);
            return GetInstance();
        }

        public MainPage EnterDestinationAirport(string destinationAirport)
        {
            _driver.FindElement(By.Id(txtToId)).SendKeys(destinationAirport);
            return GetInstance();
        }

        public MainPage SetDepartDate(string departDate)
        {
            var dayRegEx = "^[0-9]{2}$ ";
            _driver.FindElement(By.Id(btnDepartId)).ClickEx();
            var regexpMatch = Regex.Match(departDate, dayRegEx, RegexOptions.IgnoreCase);
            var departureMonth = departDate.Substring(regexpMatch.Index + 3);
            new SelectElement(_driver.FindElement(By.Id(ddlDepartMonthId))).SelectByText(departureMonth);
            _driver.FindElement(By.CssSelector(string.Format(btnDayCss, departDate))).ClickEx();
            return GetInstance();
        }

        public MainPage SetReturnDate(string returnDate)
        {
            var dayRegEx = "^[0-9]{2}$ ";
            _driver.FindElement(By.Id(btnReturnId)).Click();
            var regexpMatch = Regex.Match(returnDate, dayRegEx, RegexOptions.IgnoreCase);
            var returnMonth = returnDate.Substring(regexpMatch.Index + 3);
            new SelectElement(_driver.FindElement(By.Id(ddlReturnMonthId))).SelectByText(returnMonth);
            _driver.FindElement(By.CssSelector(string.Format(btnDayCss, returnDate))).ClickEx();
            return GetInstance();
        }

        public MainPage OpenCabinClassDropdown()
        {
            _driver.FindElement(By.Id(btnCabinClassId)).ClickEx();
            return GetInstance();
        }

        public MainPage SelectCabinClass(string cabinClass)
        {
            new SelectElement(_driver.FindElement(By.Id(ddlCabinClassId))).SelectByValue(cabinClass);
            return GetInstance();
        }

        public MainPage SetNumberOfAdults(int numberOfAdults)
        {
            var addAdultsButton = _driver.FindElement(By.CssSelector(btnAddAdultsCss));
            for (var i = 1; i < numberOfAdults; i++)
            {
                addAdultsButton.ClickEx();
            }
            return GetInstance();
        }

        public MainPage SetNumberOfChildren(int numberOfChildren, List<int> childrenAgeList)
        {
            var addChildrenButton = _driver.FindElement(By.CssSelector(btnAddChildrenCss));
            for (var i = 0; i < numberOfChildren; i++)
            {
                addChildrenButton.ClickEx();
                new SelectElement(_driver.FindElement(By.Id(string.Format(ddlChildAgeId, i)))).SelectByValue(childrenAgeList[i].ToString());
            }
            return GetInstance();
        }

        public MainPage ClickDone()
        {
            _driver.FindElement(By.XPath(btnDoneXpath)).ClickEx();
            return GetInstance();
        }

        public SearchResultsPage ClickSearch()
        {
            _driver.FindElement(By.CssSelector(btnSearchFlightsCss)).ClickEx();
            return SearchResultsPage.GetInstance();
        }
    }
}
