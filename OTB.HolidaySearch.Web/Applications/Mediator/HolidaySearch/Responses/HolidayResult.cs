namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses
{
   public class HolidayResult
   {
      // flight info
      public string DepartingFrom { get; set; }
      public string TravellingTo { get; set; }
      public DateTime DepartureDate { get; set; }
      public string Airline { get; set; }
      public int Price { get; set; }

      // hotel info
      public string HotelName { get; set; }
      public IEnumerable<string> LocalAirport { get; set; }
      public int Duration { get; set; }
      public int PricePerNight { get; set; }
      public DateTime ArrivalDate { get; set; }

   }
}
