using Moq;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Responses;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Flight.Handlers
{
   public class GetFlightByAnyDepartureCityQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetFlightByAnyDepartureCityQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetFlightByAnyDepartureCityQueryHandler(_databaseService.Object);
      }

      [Test]
      public async Task HandlerTest_InvokesDatabaseService()
      {
         // arrange
         var query = new GetFlightByAnyDepartureCityQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
         };

         var flightsFromCity = new FlightsResult
         {
            Flights = new List<FlightResult> { new FlightResult{} }
         };

         _databaseService.Setup(x => x.GetAllFlightsForSpecificLocation(query)).Returns(flightsFromCity);

         // act
         var actual = await _handler.Handle(query, default);
         // assert
         _databaseService.Verify(x => x.GetAllFlightsForSpecificLocation(query), Times.Once);
      }

      [Test]
      public async Task HandlerTest_ReturnsBestValueFlight()
      {
         // arrange
         var query = new GetFlightByAnyDepartureCityQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
         };

         var flightsFromCity = new FlightsResult
         {
            Flights = new List<FlightResult>
            {
               new FlightResult
               {
                  From = "LGW",
                  Price = 200,
                  To = "LPA",
                  DepartureDate = new DateTime(year: 2022, month: 11, day: 10)
               },
                  new FlightResult
               {
                  From = "LTN",
                  Price = 10,
                  To = "LPA",
                  DepartureDate = new DateTime(year: 2022, month: 11, day: 10)
               },
               new FlightResult
               {
                  From = "TFS",
                  Price = 90,
                  To = "LPA",
                  DepartureDate = new DateTime(year: 2022, month: 11, day: 10)
               }
            }
         };

         var expected = new FlightResult
         {
            From = "LTN",
            Price = 10,
            To = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10)
         };

         _databaseService.Setup(x => x.GetAllFlightsForSpecificLocation(query)).Returns(flightsFromCity);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(actual.From, Is.EqualTo(expected.From));
         Assert.That(actual.Price, Is.EqualTo(expected.Price));
         Assert.That(actual.To, Is.EqualTo(expected.To));
         Assert.That(actual.DepartureDate, Is.EqualTo(expected.DepartureDate));
      }
   }
}
