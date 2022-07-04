using Newtonsoft.Json;

namespace OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses
{
   public class FlightResult
   {
      [JsonProperty("airline")]
      public string? Airline { get; set; }
      [JsonProperty("from")]
      public string? From { get; set; }
      [JsonProperty("to")]
      public string? To { get; set; }
      [JsonProperty("price")]
      public int Price { get; set; }
      [JsonProperty("departure_date")]
      public DateTime DepartureDate { get; set; }
   }
}
