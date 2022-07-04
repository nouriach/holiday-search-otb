using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Handlers
{
   public class GetHolidaySearchQueryHandler : IRequestHandler<GetHolidayQuery, HolidayResult>
   {
      private readonly IMediator _mediator;
      public GetHolidaySearchQueryHandler(IMediator mediator)
      {
         _mediator = mediator;
      }

      public Task<HolidayResult> Handle(GetHolidayQuery request, CancellationToken cancellationToken)
      {
         throw new NotImplementedException();
      }
   }
}
