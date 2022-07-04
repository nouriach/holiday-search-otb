using Moq;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Responses;

namespace OTB.HolidaySearch.Tests.Applications.Mediator.Hotel.Handlers
{
   public class GetHotelQueryHandlerTests
   {
      private Mock<IDatabaseService> _databaseService;
      private GetHotelQueryHandler _handler;

      [SetUp]
      public void Setup()
      {
         _databaseService = new Mock<IDatabaseService>();
         _handler = new GetHotelQueryHandler(_databaseService.Object);

      }

      [Test]
      public void HandlerTest()
      {
         // arrange
         // act
         // assert
      }

      [Test]
      public async Task HandlerTest_InvokesDatabaseService()
      {
         // arrange
         var query = new GetHotelQuery
         {

         };

         _databaseService.Setup(x => x.GetAllHotels(It.IsAny<GetAllHotelsQuery>())).Returns(It.IsAny<HotelsResult>());

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         _databaseService.Verify(x => x.GetAllHotels(It.IsAny<GetAllHotelsQuery>()), Times.Once);
      }
   }
}
