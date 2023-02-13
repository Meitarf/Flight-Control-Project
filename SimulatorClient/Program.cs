using SimulatorClient.Models;
using System.Net.Http.Json;
using t = System.Timers;

HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5114") };
var flights = await client.GetFromJsonAsync<IEnumerable<FlightDto>>("api/Flights");
//create flight every 10 seconds
t.Timer timer = new t.Timer(10000);
timer.Elapsed += (s, e) => CreateFlight();
timer.Start();
Console.ReadLine();
//create a flight with a random flight number and use "POST" from the WebAPI to add if to the DB
void CreateFlight()
{
    Random rnd = new Random();
    var flight = new FlightDto { Airline = (AirlineTypeDto)rnd.Next(0, 8), FlightNumber = rnd.Next(100, 1000).ToString(), IsDepartured = null };
    client.PostAsJsonAsync("api/Flights", flight);
    PrintFlight(flight);
}
static void PrintFlight(FlightDto flight) => Console.WriteLine($"{flight.Airline} - {flight.FlightNumber}");
Console.ReadLine();