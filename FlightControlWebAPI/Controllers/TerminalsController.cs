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
    public class TerminalsController : ControllerBase
    {
        private readonly ITerminalService terminalService;

        public TerminalsController(ITerminalService terminalService) => this.terminalService= terminalService;

        [HttpGet]
        public async Task<IEnumerable<Terminal>> GetAllTerminals() => await terminalService.GetAllTerminals();
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTerminalById(int id)
        {
            var terminal = await terminalService.GetTerminalById(id);
            return terminal == null ? NotFound() : Ok(terminal);
        }
        [HttpPost]
        public async Task<IActionResult> AddTerminal(Terminal terminal)
        {
            terminalService.CreateTerminal(terminal);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerminal(int id)
        {
            var terminal = await terminalService.GetTerminalById(id);
            if (terminal != null)
            {
                await terminalService.Delete(id);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTerminal(int id, Terminal terminal)
        {
            if (id == terminal.Id)
            {
                terminalService.Update(terminal);
            }
            return NoContent();
        }

    }

}
