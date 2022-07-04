using MediatR;
using Moq;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         Assert.That(actual, Is.EqualTo(expected));
      }

      [Test]
      public async Task HandlerTest_InvokesGetFlightQueryMediator()
      {
         // arrange
         // act
         // assert
      }

      [Test]
      public async Task HandlerTest_InvokesGetHotelQueryMediator()
      {
         // arrange
         // act
         // assert
      }
   }
}
