using FlightControlWebAPI.DAL;
using FlightControlWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightControlWebAPI.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly DataContext data;
        public LoggerService(DataContext data) => this.data = data;
        public async void CreateLogger(Logger logger)
        {
            data.Loggers.Add(logger);
            await data.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var logger = await data.Loggers.FindAsync(id);
            if (logger != null)
            {
                data.Loggers.Remove(logger);
                await data.SaveChangesAsync();
            }
        }

        public async Task<Logger> GetLoggerById(int id)
        {
            return await data.Loggers.FindAsync(id);
        }

        public async Task<IEnumerable<Logger>> GetAllLoggers()
        {
            return await data.Loggers.ToListAsync();
        }

        public async void Update(Logger logger)
        {
            data.Loggers.Update(logger);
            await data.SaveChangesAsync();
        }
    }
}
