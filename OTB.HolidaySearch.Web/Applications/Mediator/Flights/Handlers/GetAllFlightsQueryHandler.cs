using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flights.Handlers
{
   public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, FlightsResult>
   {
      private readonly IDatabaseService _service;

      public GetAllFlightsQueryHandler(IDatabaseService service)
      {
         _service = service;
      }

      public async Task<FlightsResult> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
      {
         var flights = _service.GetAllFlights(request);
         return flights;
      }
   }
}
