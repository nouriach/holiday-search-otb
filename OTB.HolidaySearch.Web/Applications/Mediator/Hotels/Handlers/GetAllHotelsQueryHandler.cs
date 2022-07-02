using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Handlers
{
   public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQuery, HotelsResult>
   {
      public Task<HotelsResult> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}
