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
    public class LoggersController : ControllerBase
    {
        private readonly ILoggerService loggerService;

        public LoggersController(ILoggerService loggerService) => this.loggerService= loggerService;
        [HttpGet]
        public async Task<IEnumerable<Logger>> GetAllLoggers() => await loggerService.GetAllLoggers();
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(int id)
        {
            var log = await loggerService.GetLoggerById(id);
            return log == null ? NotFound() : Ok(log);
        }
        [HttpPost]
        public async Task<IActionResult> AddLogger(Logger log)
        {
            loggerService.CreateLogger(log);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogger(int id)
        {
            var log = await loggerService.GetLoggerById(id);
            if (log != null)
            {
                await loggerService.Delete(id);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogger(int id, Logger log)
        {
            if (id == log.Id)
            {
                loggerService.Update(log);
            }
            return NoContent();
        }
    }
}
