using FlightControlWebAPI.DAL;
using FlightControlWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightControlWebAPI.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly DataContext data;
        public TerminalService(DataContext data) => this.data = data;
        public List<int> Terminals { get; set; }
        public async void CreateTerminal(Terminal terminal)
        {
            data.Terminals.Add(terminal);
            await data.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var terminal = await data.Terminals.FindAsync(id);
            if (terminal != null)
            {
                data.Terminals.Remove(terminal);
                await data.SaveChangesAsync();
            }
        }

        public async Task<Terminal> GetTerminalById(int id)
        {
            return await data.Terminals.FindAsync(id);
        }

        public async Task<IEnumerable<Terminal>> GetAllTerminals()
        {
            return await data.Terminals.ToListAsync();
        }

        public async void Update(Terminal terminal)
        {
            data.Terminals.Update(terminal);
            await data.SaveChangesAsync();
        }
    }
}
