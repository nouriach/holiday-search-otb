using Moq;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Flight.Handlers
{
   public class GetFlightByCityQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetFlightByCityQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetFlightByCityQueryHandler(_databaseService.Object);
      }

      [Test]
      public async Task HandlerTest_ReturnCorrectResponse_ByLowestPrice()
      {
         // arrange
         var query = new GetFlightByCityQuery
         {
            City = "London"
         };

         var flightsFromCity = new FlightsResult
         {
            Flights = new List<FlightResult>
            {
               new FlightResult
               {
                  From = "LGW",
                  Price = 200
               },
                  new FlightResult
               {
                  From = "LTN",
                  Price = 10
               }
            }
         };

         var expected = new FlightResult
         {
            From = "LTN",
            Price = 10
         };

         _databaseService.Setup(x => x.GetAllFlightsByCity(query)).Returns(flightsFromCity);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(actual.From, Is.EqualTo(expected.From));
         Assert.That(actual.Price, Is.EqualTo(expected.Price));
      }
   }
}
