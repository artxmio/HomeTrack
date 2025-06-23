using HomeTrack.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeTrack.Persistense;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        var serverVersion = new MySqlServerVersion(new Version(configuration["DatabaseSettings:ServerVersion"] 
            ?? throw new NullReferenceException("server version was null")));
        
        services.AddDbContext<HomeTrackDbContext>(options =>
        {
            options.UseMySql(connectionString, serverVersion);
        });

        services.AddScoped<IHomeTrackDbContext>(profider => 
                                                profider.GetService<HomeTrackDbContext>() 
                                             ?? throw new NullReferenceException("profider cant't be null"));

        return services;
    }
}
