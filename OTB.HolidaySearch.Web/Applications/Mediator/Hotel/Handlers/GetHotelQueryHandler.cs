using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Handlers
{
   public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelResult>
   {
      private readonly IDatabaseService _service;
      public GetHotelQueryHandler(IDatabaseService service)
      {
         _service = service;
      }
      public async Task<HotelResult> Handle(GetHotelQuery request, CancellationToken cancellationToken)
      {
         var hotels = _service.GetAllHotels(new GetAllHotelsQuery());
         var hotel = new HotelResult();

         if (hotels.Hotels.Any())
         {
            var matchingHotel = hotels.Hotels.Where(
               x => x.ArrivalDate == request.ArrivalDate
               && x.Nights == request.Duration
               && x.LocalAirports.Contains(request.LocalAirport)).FirstOrDefault();

            MapMatchingResultToResponse(hotel, matchingHotel);
         }

         return hotel;
      }

      private static void MapMatchingResultToResponse(HotelResult hotel, HotelResult? matchingHotel)
      {
         hotel.ArrivalDate = matchingHotel.ArrivalDate;
         hotel.PricePerNight = matchingHotel.PricePerNight;
         hotel.Nights = matchingHotel.Nights;
         hotel.LocalAirports = matchingHotel.LocalAirports;
         hotel.Name = matchingHotel.Name;
      }
   }
}
