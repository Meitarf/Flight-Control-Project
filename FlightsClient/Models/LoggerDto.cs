namespace FlightsClient.Models
{
    public class LoggerDto
    {
        public int Id { get; set; }
        public TerminalDto? Terminal { get; set; }
        public FlightDto? Flight { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
