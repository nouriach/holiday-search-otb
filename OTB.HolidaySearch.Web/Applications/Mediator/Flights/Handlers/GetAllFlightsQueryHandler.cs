using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flights.Handlers
{
   public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, FlightsResult>
   {
      public Task<FlightsResult> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}
