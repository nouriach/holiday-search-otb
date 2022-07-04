using Moq;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Flight.Handlers
{
   public class GetFlightQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetFlightQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetFlightQueryHandler(_databaseService.Object);
      }

      [Test]
      public async Task HandlerTest_ReturnsCorrectResponse()
      {
         // arrange
         var query = new GetFlightQuery
         {
            DepartingFrom = "XXX",
            DepartureDate = DateTime.Now.Date,
            TravellingTo = "YYY"
         };

         var expected = new FlightResult
         {
            From = query.DepartingFrom,
            DepartureDate = query.DepartureDate,
            To = query.TravellingTo
         };

         var allFlights = new FlightsResult
         {
            Flights = new List<FlightResult> {
               new FlightResult
               {
                  From = query.DepartingFrom,
                  DepartureDate = query.DepartureDate,
                  To = query.TravellingTo
               }
            }
         };

         _databaseService.Setup(x => x.GetAllFlights(It.IsAny<GetAllFlightsQuery>())).Returns(allFlights);  

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(actual.DepartureDate == expected.DepartureDate);
         Assert.That(actual.To == expected.To);
         Assert.That(actual.From == expected.From);
      }

      [Test]
      public async Task HandlerTest_InvokesDatabaseService()
      {
         // arrange
         var query = new GetFlightQuery
         {
            DepartingFrom = "XXX",
            DepartureDate = DateTime.Now.Date,
            TravellingTo = "YYY"
         };

         _databaseService.Setup(x => x.GetAllFlights(It.IsAny<GetAllFlightsQuery>())).Returns(It.IsAny<FlightsResult>());

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         _databaseService.Verify(x => x.GetAllFlights(It.IsAny<GetAllFlightsQuery>()), Times.Once);
      }
   }
}
