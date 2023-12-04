using Coren.OnlinePortal.Persistence;
using Coren.OnlinePortal.Application;
var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;
builder.Configuration.SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true);

// Add services to the container.

builder.Services.AddMapper();
builder.Services.CreateDbContext(builder.Configuration);

Coren.OnlinePortal.Application.Registration.ConfigureServices(builder.Services);



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
