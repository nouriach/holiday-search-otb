using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries
{
   public class GetAllFlightsQuery : IRequest<FlightsResult>
   {

   }
}
