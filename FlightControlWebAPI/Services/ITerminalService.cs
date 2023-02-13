using FlightControlWebAPI.Models;

namespace FlightControlWebAPI.Services
{
    public interface ITerminalService
    {
        void CreateTerminal(Terminal terminal);
        Task Delete(int id);
        Task<Terminal> GetTerminalById(int id);
        Task<IEnumerable<Terminal>> GetAllTerminals();
        void Update(Terminal terminal);
    }
}