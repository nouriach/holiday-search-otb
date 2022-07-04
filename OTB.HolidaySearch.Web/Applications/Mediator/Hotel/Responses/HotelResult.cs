using System.Collections.Generic;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses
{
   public class HotelResult
   {
      public string? Name { get; set; }
      public DateTime ArrivalDate { get; set; }
      public int PricePerNight { get; set; }
      public IEnumerable<string>? LocalAirports { get; set; }
      public int Nights { get; set; }
   }
}
