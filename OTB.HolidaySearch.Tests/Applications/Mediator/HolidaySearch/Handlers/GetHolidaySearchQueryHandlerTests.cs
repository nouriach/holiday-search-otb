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
   public class GetHolidaySearchQueryHandlerTests
   {
      private Mock<IMediator> _mediator;
      private GetHolidaySearchQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _mediator = new Mock<IMediator>();
         _handler = new GetHolidaySearchQueryHandler(_mediator.Object);
      }

      [Test]
      public async Task HandlerTest_ReturnsCorrectResponse()
      {
         // arrange
         var holidayQuery = new GetHolidayQuery
         {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = new DateTime(year: 2023, month: 07, day: 01),
            Duration = 7
         };

         var expected = new HolidayResult();

         // act
         var actual = await _handler.Handle(holidayQuery, default);

         // assert
         Assert.IsTrue(actual.GetType() == expected.GetType());
      }

      [Test]
      public async Task HandlerTest_InvokesGetFlightQueryMediator()
      {
         // arrange
         var holidayQuery = new GetHolidayQuery
         {
            DepartingFrom = "XXX",
            DepartureDate = DateTime.Now,
            Duration = 10,
            TravellingTo = "YYY"
         };

         _mediator.Setup(x => x.Send(It.IsAny<GetFlightQuery>(), default)).ReturnsAsync(It.IsAny<FlightResult>());

         // act
         var actual = await _handler.Handle(holidayQuery, default);

         // assert
         _mediator.Verify(x => x.Send(It.IsAny<GetFlightQuery>(), default), Times.Once);
      }

      [Test]
      public async Task HandlerTest_InvokesGetHotelQueryMediator()
      {
         // arrange
         var holidayQuery = new GetHolidayQuery();

         _mediator.Setup(x => x.Send(It.IsAny<GetHotelQuery>(), default)).ReturnsAsync(It.IsAny<HotelResult>());

         // act
         var actual = await _handler.Handle(holidayQuery, default);

         // assert
         _mediator.Verify(x => x.Send(It.IsAny<GetHotelQuery>(), default), Times.Once);
      }
   }
}
