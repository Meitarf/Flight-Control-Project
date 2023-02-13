using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using t = System.Timers;

namespace FlightControlWebAPI.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public AirlineType Airline { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        public virtual Terminal? Terminal { get; set; }
        public bool? IsDepartured { get; set; }
        [NotMapped]
        public Stopwatch TimerInTerminal { get; set; } = new Stopwatch();
    }
}
