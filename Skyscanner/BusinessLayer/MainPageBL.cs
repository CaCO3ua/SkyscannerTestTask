using Skyscanner.Models;
using Skyscanner.Pages;
using Skyscanner.Utils;

namespace Skyscanner.BusinessLayer
{
    class MainPageBL
    {
        public MainPageBL NavigateToSearchPage()
        {
            PageUtils.NavigateTo("https://www.skyscanner.net/");
            return new MainPageBL();
        }

        public SearchResultsBL SearchFor(SearchModel searchCriteria)
        {
            MainPage mainPage = MainPage.GetInstance();
            mainPage.GoToSkyskannerNet()
                .AcceptCookieWarning()
                .ToggleSearchType(searchCriteria.IsReturn)
                .EnterDepartureAirport(searchCriteria.DepartureAirport)
                .EnterDestinationAirport(searchCriteria.DestinationAirport)
                .SetDepartDate(searchCriteria.DepartureDate)
                .SetReturnDate(searchCriteria.ReturnDate)
                .OpenCabinClassDropdown()
                .SelectCabinClass(searchCriteria.CabinClass)
                .SetNumberOfAdults(searchCriteria.NumberOfAdults)
                .SetNumberOfChildren(searchCriteria.NumberOfChildren, searchCriteria.ChildrenAgeList)
                .ClickDone()
                .ClickSearch();

            return new SearchResultsBL();
        }
    }
}
