using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Handlers
{
   public class GetHolidaySearchQueryHandler : IRequestHandler<GetHolidayQuery, HolidayResult>
   {
      private readonly IMediator _mediator;
      public GetHolidaySearchQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public async Task<HolidayResult> Handle(GetHolidayQuery request, CancellationToken cancellationToken)
      {
         var flightQuery = new GetFlightQuery
         {
            DepartingFrom = request.DepartingFrom,
            TravellingTo = request.TravellingTo,
            DepartureDate = request.DepartureDate
         };

         var flight = await _mediator.Send(flightQuery, cancellationToken);

         var hotelQuery = new GetHotelQuery
         {
            ArrivalDate = request.DepartureDate,
            Duration = request.Duration,
            LocalAirport = request.TravellingTo
         };

         var hotel = await _mediator.Send(hotelQuery, cancellationToken);

         if(hotel == null && flight == null)
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
