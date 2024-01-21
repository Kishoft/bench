using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddRateLimiter(_ => _.AddConcurrencyLimiter(policyName: "fixed", options =>
{
    options.PermitLimit = 10;
    options.QueueLimit = 6000000;
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<Postgresql>(options =>
{
    options.UseNpgsql("Host=192.168.1.36;Database=testinpapu;Username=pguser;Password=supersecret030303;Pooling=true;Enlist=false;MaxPoolSize=1024;CommandTimeout=0;CancellationTimeout=0");
});

var app = builder.Build();

app.UseRateLimiter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
