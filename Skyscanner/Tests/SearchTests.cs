using System;
using System.Collections.Generic;
using NUnit.Framework;
using Skyscanner.BusinessLayer;
using Skyscanner.Models;

namespace Skyscanner.Tests
{
    public class Tests
    {
        private readonly SearchModel _searchCriteria = new SearchModel()
        {
            IsReturn = true,
            DepartureAirport = "Lviv (LWO)",
            DestinationAirport = "Amsterdam (AMS)",
            DepartureDate = "23 September 2021",
            ReturnDate = "27 September 2021",
            CabinClass = "Economy",
            NumberOfAdults = 3,
            NumberOfChildren = 1,
            ChildrenAgeList = new List<int> { 12 }
        };
        private readonly MainPageBL _mainPage = new MainPageBL();
        private readonly SearchResultsBL _searchResultsPage = new SearchResultsBL();

        [Test]
        public void SearchTest()
        {
            _mainPage.NavigateToSearchPage()
                .SearchFor(_searchCriteria);

            _searchResultsPage.VerifyDepartureAirport(_searchCriteria)
                .VerifyDestinationAirport(_searchCriteria)
                .VerifyNumberOfTravellers(_searchCriteria)
                .VerifyCabinClass(_searchCriteria);

            Console.WriteLine(_searchResultsPage.GetBestFlight());
        }
    }
}