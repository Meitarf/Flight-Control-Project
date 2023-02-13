using System.ComponentModel.DataAnnotations;

namespace FlightControlWebAPI.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public double WaitingTimeSeconds { get; set; }
        public bool IsFree { get; set; } = true;
    }
}
