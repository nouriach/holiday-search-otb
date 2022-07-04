using MediatR;
using Microsoft.AspNetCore.Mvc;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.HolidaySearch.Queries;
using OTB.HolidaySearch.Web.Applications.Mediator.Hotels.Queries;

namespace OTB.HolidaySearch.Web.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class HolidaySearchController : Controller
   {
      private readonly IMediator _mediator;

      public HolidaySearchController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpGet]
      [Route("/get-holiday")]
      public async Task<IActionResult> GetHoliday([FromQuery] GetHolidayQuery query)
      {
         var holiday = await _mediator.Send(query, default);
         if(holiday == null)
         {
            return BadRequest();
         }
         return Ok(holiday);
      }

      [HttpGet]
      [Route("/get-holiday-by-city")]
      public async Task<IActionResult> GetHolidayByCity([FromQuery] GetHolidayByCityQuery query)
      {
         var holiday = await _mediator.Send(query, default);
         if (holiday == null)
         {
            return BadRequest();
         }
         return Ok(holiday);
      }

      [HttpGet]
      [Route("/get-hotels")]
      public async Task<IActionResult> GetAllHotels([FromQuery] GetAllHotelsQuery query)
      {
         var hotels = await _mediator.Send(query, default);
         if(hotels == null)
         {
            return BadRequest();  
         }
         return Ok(hotels);
      }

      [HttpGet]
      [Route("/get-flights")]
      public async Task<IActionResult> GetAllFlights([FromQuery] GetAllFlightsQuery query)
      {
         var flights = await _mediator.Send(query, default);
         if (flights == null)
         {
            return BadRequest();
         }
         return Ok(flights);
      }
   }
}
