using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TicketingSolution.Core;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Persistence;
using TicketingSolution.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var connString = configuration["ConnectionStrings:DefaultDbContext"];
var conn = new SqliteConnection(connString);
conn.Open();

builder.Services.AddDbContext<TicketingSolutionDbContext>(opt => opt.UseSqlite(conn));

builder.Services.AddScoped<ITicketBookingRequestHandler, TicketBookingRequestHandler>();
builder.Services.AddScoped<ITicketBookingService, TicketBookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
