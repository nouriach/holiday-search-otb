using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Handlers
{
   public class GetHolidayByAnyDepartureLocationQueryHandler : IRequestHandler<GetHolidayByAnyDepartureLocationQuery, HolidayResult>
   {
      private readonly IMediator _mediator;

      public GetHolidayByAnyDepartureLocationQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }
      public async Task<HolidayResult> Handle(GetHolidayByAnyDepartureLocationQuery request, CancellationToken cancellationToken)
      {
         var flightQuery = new GetFlightByAnyDepartureCityQuery
         {
            DepartureDate = request.DepartureDate,
            TravellingTo = request.TravellingTo
         };

         var flight = await _mediator.Send(flightQuery, cancellationToken);

         var hotelQuery = new GetHotelQuery
         {
            ArrivalDate = request.DepartureDate,
            Duration = request.Duration,
            LocalAirport = request.TravellingTo
         };

         var hotel = await _mediator.Send(hotelQuery, cancellationToken);

         if (hotel == null && flight == null)
         {
            return new HolidayResult();
         }

         return new HolidayResult
         {
            DepartingFrom = flight.From,
            TravellingTo = flight.To,
            DepartureDate = flight.DepartureDate,
            Airline = flight.Airline ?? "",
            Price = flight.Price,
            HotelName = hotel.Name ?? "",
            LocalAirport = new List<string>(hotel.LocalAirports),
            Duration = hotel.Nights,
            PricePerNight = hotel.PricePerNight,
            ArrivalDate = hotel.ArrivalDate,
         };
      }
   }
}
