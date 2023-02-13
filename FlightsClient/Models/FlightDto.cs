using System.Diagnostics;

namespace FlightsClient.Models
{
    public class FlightDto
    {
        public int Id { get; set; }
        public AirlineTypeDto Airline { get; set; }
        public string FlightNumber { get; set; }
        public TerminalDto? Terminal { get; set; }
        public bool? IsDepartured { get; set; }
        public Stopwatch TimerInTerminal { get; set; } = new Stopwatch();
    }
}
