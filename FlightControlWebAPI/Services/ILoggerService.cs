using FlightControlWebAPI.Models;

namespace FlightControlWebAPI.Services
{
    public interface ILoggerService
    {
        void CreateLogger(Logger logger);
        Task Delete(int id);
        Task<Logger> GetLoggerById(int id);
        Task<IEnumerable<Logger>> GetAllLoggers();
        void Update(Logger logger);
        
    }
}