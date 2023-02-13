using FlightControlWebAPI.DAL;
using FlightControlWebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("FlightControlDb")));
builder.Services.AddTransient<IFlightService, FlightService>();
builder.Services.AddTransient<ITerminalService, TerminalService>();
builder.Services.AddTransient<ILoggerService, LoggerService>();
//builder.Services.AddScoped<FlightService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
