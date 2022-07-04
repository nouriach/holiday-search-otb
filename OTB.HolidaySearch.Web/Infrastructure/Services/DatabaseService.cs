using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Web.Infrastructure.Services
{
   public class DatabaseService : IDatabaseService
   {
      public FlightsResult GetAllFlights(GetAllFlightsQuery query)
      {
         var flights = new FlightsResult();
         return flights;
      }

      public HotelsResult GetAllHotels(GetAllHotelsQuery query)
      {
         var hotels = new HotelsResult();
         return hotels;
      }
   }
}
