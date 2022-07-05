using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries
{
   public class GetFlightByAnyDepartureCityQuery : IRequest<FlightResult>
   {
      public string TravellingTo { get; set; }
      public DateTime DepartureDate { get; set; }
   }
}
