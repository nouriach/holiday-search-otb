using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries
{
   public class GetHolidayQuery : IRequest<HolidayResult>
   {
      public string DepartingFrom { get; set; }
      public string TravellingTo { get; set; }
      public DateTime DepartureDate { get; set; }
      public int Duration { get; set; }
   }
}
