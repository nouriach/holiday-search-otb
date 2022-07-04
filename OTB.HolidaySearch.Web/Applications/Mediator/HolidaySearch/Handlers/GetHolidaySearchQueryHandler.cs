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

         var holiday = new HolidayResult
         {
            // render with the result of the above searches
         };

         return holiday;
      }
   }
}
