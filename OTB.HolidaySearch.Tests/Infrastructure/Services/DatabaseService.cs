using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
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
   }
}
