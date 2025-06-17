using HomeTrack.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HomeTrack.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(provider => provider.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}