namespace OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries
{
   public class GetHolidayBaseQuery
   {
      public string TravellingTo { get; set; }
      public DateTime DepartureDate { get; set; }
      public int Duration { get; set; }
   }
}
