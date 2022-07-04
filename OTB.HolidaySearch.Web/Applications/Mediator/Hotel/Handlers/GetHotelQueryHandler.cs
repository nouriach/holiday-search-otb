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

         return hotel;
      }
   }
}
