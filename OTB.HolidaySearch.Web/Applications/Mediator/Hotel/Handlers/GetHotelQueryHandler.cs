using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Handlers
{
   public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, HotelResult>
   {
      public Task<HotelResult> Handle(GetHotelQuery request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}
