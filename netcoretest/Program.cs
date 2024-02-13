using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = null;
    // Request timeout
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
    // Otros ajustes según sea necesario
});
builder.Services.AddRateLimiter(_ => _.AddConcurrencyLimiter(policyName: "concurrent", options =>
{
    options.PermitLimit = 100;
    options.QueueLimit = int.MaxValue;
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<Postgresql>(options =>
{
    options.UseNpgsql("Host=postgresql;Database=testinpapu;Username=ezequiel;Password=chichito;Pooling=true;CommandTimeout=0;CancellationTimeout=0");
}, 100);

var app = builder.Build();

app.UseRateLimiter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
