using Microsoft.EntityFrameworkCore;
using netcoretest.Databases;

public class WeatherForecastScopedFactory : IDbContextFactory<Postgresql>
{
    private const int DefaultTenantId = -1;

    private readonly IDbContextFactory<Postgresql> _pooledFactory;
    private readonly int _tenantId;

    public WeatherForecastScopedFactory(
        IDbContextFactory<Postgresql> pooledFactory)
    {
        _pooledFactory = pooledFactory;
    }

    public Postgresql CreateDbContext()
    {
        var context = _pooledFactory.CreateDbContext();
        return context;
    }
}