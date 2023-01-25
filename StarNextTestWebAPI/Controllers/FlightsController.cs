using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarNextTestWebAPI.Models.DAL;
using StarNextTestWebAPI.Models;

namespace StarNextTestWebAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/flight")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightDataService _flightDataService;

        public FlightsController(FlightDataService flightDataService)
        {
            _flightDataService = flightDataService;
        }

        //[HttpGet]
        [HttpGet("search")]
        public ActionResult<List<Flight>> Get()
        {
            var flights = _flightDataService.GetFlights();
            return Ok(flights);
        }
    }
}
