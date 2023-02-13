using FlightControlWebAPI.DAL;
using FlightControlWebAPI.Models;
using FlightControlWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightControlWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly IFlightService flightService;
        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        [HttpGet]
        public async Task<IEnumerable<Flight>> GetAllFlights() => await flightService.GetAllFlights();
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await flightService.GetFlightById(id);
            return flight == null ? NotFound() : Ok(flight);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            await flightService.AddFlightAsync(flight);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await flightService.GetFlightById(id);
            if (flight != null)
            {
                await flightService.Delete(id);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, Flight flight)
        {
            if (id == flight.Id)
            {
                flightService.Update(flight); 
            }
            return NoContent();
        }
    }
}
