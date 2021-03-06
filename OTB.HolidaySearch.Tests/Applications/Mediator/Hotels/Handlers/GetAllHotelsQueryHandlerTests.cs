using Moq;
using NUnit.Framework;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Hotels.Handlers
{
   public class GetAllHotelsQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetAllHotelsQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetAllHotelsQueryHandler(_databaseService.Object);
      }

      [Test]
      public async Task HandlerTest_ReturnsCorrectResponse()
      {
         // arrange
         var query = new GetAllHotelsQuery();
         var expected = new HotelsResult { Hotels = new List<HotelResult>() };
         _databaseService.Setup(x => x.GetAllHotels(query)).Returns(expected);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(actual, Is.EqualTo(expected));
         Assert.IsNotNull(actual);
      }

      [Test]
      public async Task HandlerTest_InvokesDatabaseServiceOnce()
      {
         // arrange
         var query = new GetAllHotelsQuery();
         var expected = new HotelsResult { Hotels = new List<HotelResult>() };
         _databaseService.Setup(x => x.GetAllHotels(query)).Returns(expected);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         _databaseService.Verify(x => x.GetAllHotels(query), Times.Once);
      }
   }
}
