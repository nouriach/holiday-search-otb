using MediatR;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Handlers
{
   public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, HotelsResult>
   {
      private readonly IDatabaseService _service;

      public GetAllHotelsQueryHandler(IDatabaseService service)
      {
         _service = service;
      }

      public async Task<HotelsResult> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
      {
         var hotels = _service.GetAllHotels(request);
         return hotels;
      }
   }
}
