using System.Collections.Generic;

namespace Skyscanner.Models
{
    class SearchModel
    {
        public bool IsReturn;
        public string DepartureAirport;
        public string DestinationAirport;
        public string DepartureDate;
        public string ReturnDate;
        public string CabinClass;
        public int NumberOfAdults;
        public int NumberOfChildren;
        public List<int> ChildrenAgeList;
    }
}
