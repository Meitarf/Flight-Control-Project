namespace SimulatorClient.Models
{
    public class TerminalDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double WaitingTimeSeconds { get; set; }
        public bool IsFree { get; set; } = true;
    }
}