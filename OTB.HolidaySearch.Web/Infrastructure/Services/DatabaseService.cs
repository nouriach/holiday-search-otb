using Newtonsoft.Json;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
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
         using (StreamReader reader = new StreamReader("C:/Users/nathan.ouriach/source/repos/Misc/TechTests/OnTheBeach/OTB.HolidaySearch/OTB.HolidaySearch.Web/Infrastructure/Data/flightData.json"))
         {
            var json = reader.ReadToEnd();
            flights = JsonConvert.DeserializeObject<FlightsResult> (json);
         }

         return flights;
      }

      public HotelsResult GetAllHotels(GetAllHotelsQuery query)
      {
         var hotels = new HotelsResult();
         using (StreamReader reader = new StreamReader("C:/Users/nathan.ouriach/source/repos/Misc/TechTests/OnTheBeach/OTB.HolidaySearch/OTB.HolidaySearch.Web/Infrastructure/Data/hotelData.json"))
         {
            var json = reader.ReadToEnd();
            hotels = JsonConvert.DeserializeObject<HotelsResult>(json);
         }
         return hotels;
      }
   }
}
