using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Web.Applications.Common.Interfaces
{
   public interface IDatabaseService
   {
      FlightsResult GetAllFlights(GetAllFlightsQuery query);
      HotelsResult GetAllHotels(GetAllHotelsQuery query);
      FlightsResult GetAllFlightsByCity(GetFlightByCityQuery query);
      FlightsResult GetAllFlightsForSpecificLocation(GetFlightByAnyDepartureCityQuery query);
   }
}
