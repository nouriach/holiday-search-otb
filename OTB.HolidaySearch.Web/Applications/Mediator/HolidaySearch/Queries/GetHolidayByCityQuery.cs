using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries
{
   public class GetHolidayByCityQuery : GetHolidayBaseQuery, IRequest<HolidayResult>
   {
      public string DepartingFromCity { get; set; }
   }
}
