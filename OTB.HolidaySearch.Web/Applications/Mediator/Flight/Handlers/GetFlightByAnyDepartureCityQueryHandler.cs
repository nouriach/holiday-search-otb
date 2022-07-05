using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers
{
   public class GetFlightByAnyDepartureCityQueryHandler : IRequestHandler<GetFlightByAnyDepartureCityQuery, FlightResult>
   {
      private readonly IDatabaseService _service;

      public GetFlightByAnyDepartureCityQueryHandler(IDatabaseService service)
      {
         _service = service;
      }
      public async Task<FlightResult> Handle(GetFlightByAnyDepartureCityQuery request, CancellationToken cancellationToken)
      {
         var flights = _service.GetAllFlightsForSpecificLocation(request);
         if(flights.Flights == null)
         {
            return new FlightResult(); ;
         }
         var bestValueFlight = flights.Flights.OrderBy(x => x.Price).First();
         return bestValueFlight;
      }
   }
}
