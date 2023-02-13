using FlightControlWebAPI.DAL;
using FlightControlWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimulatorClient.Models;
using System.Runtime.CompilerServices;

namespace FlightControlWebAPI.Services
{
    public class FlightService : IFlightService
    {
        
        private readonly DataContext data;
        public List<Terminal> Terminals;

        public FlightService(DataContext data)
        {
            this.data = data;
            SetTerminals();
        }
        private void SetTerminals() => Terminals = data.Terminals.ToList();

        public async Task Delete(int id)
        {
            var flight = await data.Flights.FindAsync(id);
            if (flight != null)
            {
                data.Flights.Remove(flight);
                await data.SaveChangesAsync();
            }
        }
        public async Task<Flight> GetFlightById(int id)
        {
            return await data.Flights.FindAsync(id);
        }

        public async Task<IEnumerable<Flight>> GetAllFlights()
        {
            return await data.Flights.ToListAsync();
        }

        public async void Update(Flight flight)
        {
            data.Flights.Update(flight);
            await data.SaveChangesAsync();
        }

        private Terminal? GetTerminalByNumber(int number) => Terminals.FirstOrDefault(t => t.Number == number);
        // add flight to db and move it through all the terminals, begining on terminal 1
        public async Task AddFlightAsync(Flight flight)
        {
            data.Flights.Add(flight);
            GoNextLeg(flight, 1);
            GoNextTerminal(flight);
            await data.SaveChangesAsync();
        }
        
        private void GoNextLeg(Flight flight, int terminalNumber)
        {
            flight.TimerInTerminal.Stop();
            // find the terminal 
            flight.Terminal = GetTerminalByNumber(terminalNumber);
            // write in log
            AddFlightToLog(flight);
            // wait the needed time in the terminal
            Thread.Sleep((int)flight.Terminal.WaitingTimeSeconds * 1000);
            // update that the terminal is occupied and save
            flight.Terminal.IsFree = false;
            data.Terminals.Update(flight.Terminal);
            data.SaveChanges();
            // flight continues
            flight.TimerInTerminal.Start();
            // update that terminal is free and save
            flight.Terminal.IsFree = true;
            data.Terminals.Update(flight.Terminal);
            data.SaveChanges();
        }

        private async Task AddFlightToLog(Flight flight)
        {
            try
            {
                //check if this flight has a log already
                var lastLog = data.Loggers.FirstOrDefault(l => l.Flight.Id == flight.Id && l.Out == null);
                //if it has - update the current logs' Out time and create a new log
                if (lastLog != null)
                {
                    lastLog.Out = DateTime.Now;
                    data.Loggers.Add(new Logger { Flight = flight, In = DateTime.Now, Terminal = flight.Terminal });
                    await data.SaveChangesAsync();
                }
                //if not - just add a new log
                else
                {
                    data.Loggers.Add(new Logger { Flight = flight, In = DateTime.Now, Terminal = flight.Terminal });
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task GoNextTerminal(Flight flight)
        {
            // until terminal 5 the route is the same route (1-2-3-4-5)
            while (flight.Terminal.Number < 5)
            {
                CheckNextTerminal(flight);
            }
            if (flight.Terminal.Number == 5)
            {
                //if terminal 6 is free - go to terminal 6
                var nextTerminal = GetTerminalByNumber(flight.Terminal.Number + 1);
                if (nextTerminal.IsFree) GoNextLeg(flight, flight.Terminal.Number + 1);
                else
                {
                    //if terminal 6 isn't free - check if terminal 7 is free
                    CheckTerminalByNumber(flight, 7);
                }
            }
            //from terminal 6 or 7 - go to terminal 8
            if (flight.Terminal.Number == 6 || flight.Terminal.Number == 7)
            {
                CheckTerminalByNumber(flight, 8);

            }
            //from terminal 8 - go to terminal 4
            if (flight.Terminal.Number == 8)
            {
                CheckTerminalByNumber(flight, 4);
            }
            var lastLog = data.Loggers.FirstOrDefault(l => l.Flight.Id == flight.Id && l.Out == null);
            if (lastLog != null)
            {
                lastLog.Out = DateTime.Now;
                await UpdateFlightsAndSave(flight);
            }
            else
            {
                await UpdateFlightsAndSave(flight);
            }
        }

        private async Task UpdateFlightsAndSave(Flight flight)
        {
            flight.Terminal = null;
            flight.IsDepartured = true;
            //update flight has departured
            data.Flights.Update(flight);
            data.SaveChanges();
            //add log and save changes
            data.Loggers.Add(new Logger { Flight = flight, In = DateTime.Now, Terminal = flight.Terminal });
            await data.SaveChangesAsync();
        }

        private void CheckNextTerminal(Flight flight)
        {
            //check if the next terminal is free
            var nextTerminal = GetTerminalByNumber(flight.Terminal.Number + 1);
            //if free - Go next terminal
            if (nextTerminal.IsFree) GoNextLeg(flight, flight.Terminal.Number + 1);
            //if not free - stay in the same terminal
            else GoNextLeg(flight, flight.Terminal.Number);
        }
        private void CheckTerminalByNumber(Flight flight, int terminalNumber)
        {
            //check if the next terminal is free
            var nextTerminal = GetTerminalByNumber(terminalNumber);
            //if free - Go next terminal
            if (nextTerminal.IsFree) GoNextLeg(flight, terminalNumber);
            //if not free - stay in the same terminal
            else GoNextLeg(flight, flight.Terminal.Number);
        }
    }
}
