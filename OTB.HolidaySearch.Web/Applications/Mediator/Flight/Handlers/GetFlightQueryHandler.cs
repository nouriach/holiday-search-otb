using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers
{
   public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, FlightResult>
   {
      public Task<FlightResult> Handle(GetFlightQuery request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}
