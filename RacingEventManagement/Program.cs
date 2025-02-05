using RacingEventManagement.Models.Context;
using RacingEventManagement.Repos;
using RacingEventManagement.Service;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("System.Globalization.Invariant", false);

// Add services to the container.
builder.Services.AddScoped<RaceRepo>();
builder.Services.AddScoped<RaceService>();

builder.Services.AddDbContext<RacingContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
