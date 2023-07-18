using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Postgresql>(options =>
{
    options.UseNpgsql("Host=postgresql;Database=testinpapu;Username=ezequiel;Password=chichito;Pooling=true;MinPoolSize=800;MaxPoolSize=12000;NoResetOnClose=true;MaxAutoPrepare=10;Timeout=1000;CommandTimeout=1000;Keepalive=1;KeepaliveIdle=1;KeepaliveInterval=1");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
