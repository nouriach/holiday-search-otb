using Moq;
using NUnit.Framework;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Flights.Handlers
{
   public class GetAllFlightsQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetAllFlightsQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetAllFlightsQueryHandler(_databaseService.Object);
      }

      [Test]
      public async Task HandlerTest_ReturnsCorrectResponse()
      {
         // arrange
         var query = new GetAllFlightsQuery();
         var expected = new FlightsResult { Flights = new List<FlightResult>() };



         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(actual, Is.EqualTo(expected));
         Assert.IsNotNull(actual);
      }
   }
}
