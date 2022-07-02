namespace OTB.HolidaySearch.Web.Domain.Models
{
   public class Hotel
   {
      public int Id { get; set; }
      public DateTime ArrivalData { get; set; }
      public string? PricePerNight { get; set; }
      public IEnumerable<string>? LocalAirports { get; set; }
      public int Nights { get; set; }

   }
}
