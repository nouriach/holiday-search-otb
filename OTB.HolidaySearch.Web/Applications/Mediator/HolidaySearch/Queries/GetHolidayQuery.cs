using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries
{
   public class GetHolidayQuery : GetHolidayBaseQuery, IRequest<HolidayResult>
   {
      public string DepartingFrom { get; set; }
   }
}
