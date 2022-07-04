namespace OTB.HolidaySearch.Web.Domain.Constants
{
   public static class CityDictionary
   {
      public static readonly Dictionary<string, string[]> Cities = new Dictionary<string, string[]>()
        {
            { "london", new string[]{ "LGW", "LTN" } },
            { "manchester", new string[]{ "MAN" } },
            { "mallorca", new string[]{ "PMI" } },
            { "malaga", new string[]{ "AGP" } },
            { "tenerife", new string[]{ "TFS" } },
            { "las palmas", new string[]{ "LPA" } }
        };
   }
}
