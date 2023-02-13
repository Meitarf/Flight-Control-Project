using FlightControlWebAPI.Models;
using SimulatorClient.Models;

namespace FlightControlWebAPI.Services
{
    public interface IFlightService
    {
        Task Delete(int id);
        Task<Flight> GetFlightById(int id);
        Task<IEnumerable<Flight>> GetAllFlights();
        void Update(Flight flight);
        Task AddFlightAsync(Flight flight);

    }
}