using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers
{
   public class GetFlightByCityQueryHandler : IRequestHandler<GetFlightByCityQuery, FlightResult>
   {
      private readonly IDatabaseService _service;
      public GetFlightByCityQueryHandler(IDatabaseService databaseService)
      {
         _service = databaseService;
      }
      public async Task<FlightResult> Handle(GetFlightByCityQuery request, CancellationToken cancellationToken)
      {
         var flights = _service.GetAllFlightsByCity(request);
         if (flights.Flights == null)
         {
            return new FlightResult(); ;
         }
         var bestValueFlight = flights.Flights.OrderBy(x => x.Price).First();

         return bestValueFlight;
      }
   }
}
