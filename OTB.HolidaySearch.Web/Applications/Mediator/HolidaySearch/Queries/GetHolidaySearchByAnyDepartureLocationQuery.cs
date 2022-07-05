using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries
{
   public class GetHolidayByAnyDepartureLocationQuery : GetHolidayBaseQuery, IRequest<HolidayResult>
   {
   }
}
