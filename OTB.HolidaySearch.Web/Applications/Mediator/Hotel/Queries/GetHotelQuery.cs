using MediatR;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries
{
   public class GetHotelQuery : IRequest<HotelResult>
   {
      public DateTime ArrivalDate { get; set; }
      public string LocalAirport { get; set; }
      public int Duration { get; set; }
   }
}
