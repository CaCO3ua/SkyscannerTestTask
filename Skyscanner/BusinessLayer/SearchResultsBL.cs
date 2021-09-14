using NUnit.Framework;
using Skyscanner.Models;
using Skyscanner.Pages;

namespace Skyscanner.BusinessLayer
{
    class SearchResultsBL
    {
        public SearchResultsBL VerifyDepartureAirport(SearchModel searchModel)
        {
            Assert.AreEqual(searchModel.DepartureAirport, SearchResultsPage.GetInstance().GetDepartureAirport(), "Departure airport is incorrect");
            return new SearchResultsBL();
        }

        public SearchResultsBL VerifyDestinationAirport(SearchModel searchModel)
        {
            Assert.AreEqual(searchModel.DestinationAirport, SearchResultsPage.GetInstance().GetDestinationAirport(), "Destination airport is incorrect");
            return new SearchResultsBL();
        }

        public SearchResultsBL VerifyNumberOfTravellers(SearchModel searchModel)
        {
            Assert.AreEqual(searchModel.NumberOfAdults + searchModel.NumberOfChildren, SearchResultsPage.GetInstance().GetNumberOfTravellers(), "Number of travellers is incorrect");
            return new SearchResultsBL();
        }

        public SearchResultsBL VerifyCabinClass(SearchModel searchModel)
        {
            Assert.AreEqual(searchModel.CabinClass, SearchResultsPage.GetInstance().GetCabinClass(), "Cabin class is incorrect");
            return new SearchResultsBL();
        }

        public string GetBestFlight()
        {
            return
                $"Cheapest flight price is {SearchResultsPage.GetInstance().GetFirstFlightPrice()}. Outbound flight time is {SearchResultsPage.GetInstance().GetFirstOutboundFlightTime()}. Return flight time is {SearchResultsPage.GetInstance().GetFirstReturnFlightTime()}.";
        }
    }
}
