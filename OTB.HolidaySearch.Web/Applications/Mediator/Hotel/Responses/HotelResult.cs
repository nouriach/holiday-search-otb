using Newtonsoft.Json;
using System.Collections.Generic;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses
{
   public class HotelResult
   {
      [JsonProperty("name")]
      public string? Name { get; set; }
      [JsonProperty("arrival_date")]
      public DateTime ArrivalDate { get; set; }
      [JsonProperty("price_per_night")]
      public int PricePerNight { get; set; }
      [JsonProperty("local_airports")]
      public IEnumerable<string>? LocalAirports { get; set; }
      [JsonProperty("nights")]
      public int Nights { get; set; }
   }
}
