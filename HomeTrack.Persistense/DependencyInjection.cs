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

        services.AddDbContext<HomeTrackDbContext>(options =>
        {
            options.UseMySql(connectionString);
        });

        services.AddScoped<IHomeTrackDbContext>(profider => 
                                                profider.GetService<HomeTrackDbContext>() 
                                             ?? throw new NullReferenceException("profider cant't be null"));

        return services;
    }
}
