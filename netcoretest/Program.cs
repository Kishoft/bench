using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(opt => {
    opt.Limits.MaxConcurrentConnections = 2200;
    opt.Limits.MaxConcurrentUpgradedConnections = 2200;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Postgresql>(options =>
{
    options.UseNpgsql("Host=postgresql;Database=testinpapu;Username=ezequiel;Password=chichito");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
