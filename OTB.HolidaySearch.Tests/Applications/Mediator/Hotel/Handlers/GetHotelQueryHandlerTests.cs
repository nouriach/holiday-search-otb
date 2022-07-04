using Moq;
using OTB.HolidaySearch.Web.Applications.Common.Interfaces;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Handlers;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotel.Responses;
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
      public async Task HandlerTest_ReturnsCorrectResponse()
      {
         // arrange
         var query = new GetHotelQuery
         {
            ArrivalDate = DateTime.Now,
            Duration = 12,
            LocalAirport = "XXX"
         };

         var expected = new HotelResult
         {
            Name = "Test Hotel Name",
            ArrivalDate = query.ArrivalDate,
            LocalAirports = new List<string> { query.LocalAirport },
            Nights = query.Duration,
            PricePerNight = 150
         };

         var allHotels = new HotelsResult
         {
            Hotels = new List<HotelResult> { expected, new HotelResult() }
         };

         _databaseService.Setup(x => x.GetAllHotels(It.IsAny<GetAllHotelsQuery>())).Returns(allHotels);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         Assert.That(expected.Nights == actual.Nights);
         Assert.That(expected.LocalAirports == actual.LocalAirports);
         Assert.That(expected.PricePerNight == actual.PricePerNight);
         Assert.That(expected.ArrivalDate == actual.ArrivalDate);
         Assert.That(expected.Name == actual.Name);
      }

      [Test]
      public async Task HandlerTest_InvokesDatabaseService()
      {
         // arrange
         var query = new GetHotelQuery
         {
            ArrivalDate = DateTime.Now,
            Duration = 10,
            LocalAirport = "XXX"
         };

         var hotels = new HotelsResult
         {
            Hotels = new List<HotelResult>
            {
               new HotelResult
               {
                  ArrivalDate = query.ArrivalDate,
                  Nights = query.Duration,
                  LocalAirports = new List<string> { query.LocalAirport }
               }
            }
         };

         _databaseService.Setup(x => x.GetAllHotels(It.IsAny<GetAllHotelsQuery>())).Returns(hotels);

         // act
         var actual = await _handler.Handle(query, default);

         // assert
         _databaseService.Verify(x => x.GetAllHotels(It.IsAny<GetAllHotelsQuery>()), Times.Once);
      }
   }
}
