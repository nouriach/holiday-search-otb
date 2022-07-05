using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB.HolidaySearch.Tests.Infrastructure.Services
{
   public class DatabaseServiceTests
   {
      private IDatabaseService _databaseService;

      [SetUp]
      public void Setup()
      {
         _databaseService = new DatabaseService();
      }

      [Test]
      public void DatabaseServiceTest_ReturnsAllHotels()
      {
         // arrange
         var query = new GetAllHotelsQuery();

         // act
         var actual = _databaseService.GetAllHotels(query);

         // assert
         Assert.IsNotNull(actual);
      }

      [Test]
      public void DatabaseServiceTest_ReturnsAllFlights()
      {
         // arrange
         var query = new GetAllFlightsQuery();

         // act
         var actual = _databaseService.GetAllFlights(query);

         // assert
         Assert.IsNotNull(actual);
      }

      [Test]
      public void DatabaseServiceTest_ReturnsAllFlights_BySpecificCityAndDestinationAndDate()
      {
         // arrange
         var query = new GetFlightByCityQuery
         {
            City = "London",
            DepartureDate = new DateTime(year: 2023, month: 06, day: 15),
            TravellingTo = "PMI"
         };

         // act
         var actual = _databaseService.GetAllFlightsByCity(query);

         // assert
         Assert.IsNotNull(actual);
         Assert.IsTrue(actual.Flights.Count() == 2);
      }

      [Test]
      public void DatabaseService_ReturnsAllFlights_BySpecificDestinationAndDate()
      {
         // arrange
         var query = new GetFlightByAnyDepartureCityQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
         };

         var expected = new FlightResult
         {
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
            To = "LPA",
            From = "MAN",
            Price = 125,
            Airline = "Trans American Airlines"
         };

         // act
         var actual = _databaseService.GetAllFlightsForSpecificLocation(query);

         // assert
         var actualFlight = actual.Flights.First();

         Assert.IsNotNull(actual);
         Assert.IsTrue(actualFlight.DepartureDate ==  expected.DepartureDate);
         Assert.IsTrue(actualFlight.To == expected.To);
         Assert.IsTrue(actualFlight.From == expected.From);
         Assert.IsTrue(actualFlight.Price == expected.Price);
         Assert.IsTrue(actualFlight.Airline == expected.Airline);
      }
   }
}
