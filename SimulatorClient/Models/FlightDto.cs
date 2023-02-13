using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorClient.Models
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
