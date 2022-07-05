using MediatR;
using Moq;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Flight.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.HolidaySearch.Handlers
{
   public class GetHolidayByAnyDepartureLocationQueryHandlerTests
   {
      private Mock<IMediator> _mediator;
      private GetHolidayByAnyDepartureLocationQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _mediator = new Mock<IMediator>();
         _handler = new GetHolidayByAnyDepartureLocationQueryHandler(_mediator.Object);
      }

      [Test]
      public async Task HandlerTest__ReturnsCorrectResponse()
      {
         //arrange
         var holidayQuery = new GetHolidayByAnyDepartureLocationQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
            Duration = 14
         };

         var expected = new HolidayResult();

         //act
         var actual = await _handler.Handle(holidayQuery, default);

         //assert
         Assert.IsTrue(actual.GetType() == expected.GetType());
      }


      [Test]
      public async Task HandlerTest_InvokesGetFlightByAnyCityQueryMediator()
      {
         // arrange
         var holidayQuery = new GetHolidayByAnyDepartureLocationQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
            Duration = 14
         };

         _mediator.Setup(x => x.Send(It.IsAny<GetFlightByAnyDepartureCityQuery>(), default)).ReturnsAsync(It.IsAny<FlightResult>());

         // act
         var actual = await _handler.Handle(holidayQuery, default);

         // assert
         _mediator.Verify(x => x.Send(It.IsAny<GetFlightByAnyDepartureCityQuery>(), default), Times.Once);
      }
      [Test]
      public async Task HandlerTest_InvokesGetHotelQueryMediator()
      {
         // arrange
         var holidayQuery = new GetHolidayByAnyDepartureLocationQuery
         {
            TravellingTo = "LPA",
            DepartureDate = new DateTime(year: 2022, month: 11, day: 10),
            Duration = 14
         };
         _mediator.Setup(x => x.Send(It.IsAny<GetHotelQuery>(), default)).ReturnsAsync(It.IsAny<HotelResult>());

         // act
         var actual = await _handler.Handle(holidayQuery, default);

         // assert
         _mediator.Verify(x => x.Send(It.IsAny<GetHotelQuery>(), default), Times.Once);
      }

   }
}
