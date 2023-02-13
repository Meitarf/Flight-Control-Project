using System.ComponentModel.DataAnnotations;

namespace FlightControlWebAPI.Models
{
    public class Logger
    {
        public int Id { get; set; }
        [Required]
        public virtual Terminal? Terminal { get; set; }
        [Required]
        public virtual Flight? Flight { get; set; }
        [Required]
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
