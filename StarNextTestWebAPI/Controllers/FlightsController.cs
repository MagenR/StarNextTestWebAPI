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

        // Regular API GET call to be used with the FrontEnd.
        [HttpGet("search")]
        public ActionResult<List<Flight>> Get()
        {
            var flights = _flightDataService.GetFlights();
            return Ok(flights);
        }

        // Additional call for filtering flights by <2 passengers (1 flight should be returned).
        [HttpGet("search/passenger")]
        public ActionResult<List<Flight>> GetPassengerFiltered()
        {
            var flights = _flightDataService.GetFlightsPassengerFiltered();
            return Ok(flights);
        }
    }
}
