﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OTB.HolidaySearch.Web.Applications.Mediator.Flights.Queries;
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
      [Route("/get-result")]
      public IActionResult GetResult()
      {
         return Ok("Test result..");
      }

      [HttpGet]
      [Route("/get-hotels")]
      public async Task<IActionResult> GetAllHotels([FromQuery] GetAllHotelsQuery query)
      {
         var hotels = await _mediator.Send(query, default);
         return Ok(hotels);
      }

      [HttpGet]
      [Route("/get-flights")]
      public async Task<IActionResult> GetAllFlights([FromQuery] GetAllFlightsQuery query)
      {
         var flights = await _mediator.Send(query, default);
         return Ok(flights);
      }
   }
}