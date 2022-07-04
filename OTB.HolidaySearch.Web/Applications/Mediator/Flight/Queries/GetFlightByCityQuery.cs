using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries
{
   public class GetFlightByCityQuery : IRequest<FlightResult>
   {
      public string City { get; set; }
      public string TravellingTo { get; set; }
      public DateTime DepartureDate { get; set; }
   }
}
