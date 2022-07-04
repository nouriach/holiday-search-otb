using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers
{
   public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, FlightResult>
   {
      private readonly IDatabaseService _service;

      public GetFlightQueryHandler(IDatabaseService service)
      {
         _service = service;
      }
      public async Task<FlightResult> Handle(GetFlightQuery request, CancellationToken cancellationToken)
      {
         var flights = _service.GetAllFlights(new GetAllFlightsQuery());
         
         var flight = new FlightResult();

         if (flights.Flights.Any())
         {
            var matchingFlight = flights.Flights.Where(
               x => x.To == request.TravellingTo
               && x.From == request.DepartingFrom
               && x.DepartureDate == request.DepartureDate).FirstOrDefault();

            MapMatchingResultToResponse(flight, matchingFlight);
         }

         return flight;
      }

      private static void MapMatchingResultToResponse(FlightResult flight, FlightResult? matchingFlight)
      {
         flight.DepartureDate = matchingFlight.DepartureDate;
         flight.Airline = matchingFlight.Airline;
         flight.Price = matchingFlight.Price;
         flight.To = matchingFlight.To;
         flight.From = matchingFlight.From;
      }
   }
}
