using FlightControlWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightControlWebAPI.DAL
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        }
    }
}
