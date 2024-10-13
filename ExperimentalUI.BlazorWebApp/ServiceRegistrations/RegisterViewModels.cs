using ExperimentalUI.BlazorWebApp.ViewModels;
using System.Reflection;

namespace ExperimentalUI.BlazorWebApp.ServiceRegistrations;

public static class RegisterViewModels
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        AddViewModels(services, Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services, Assembly assembly)
    {
        var implementingTypes = assembly.GetTypes()
            .Where(t => typeof(IViewModel).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var type in implementingTypes)
        {
            services.AddScoped(type);
        }

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            AddViewModels(services, assembly);
        }

        return services;
    }
}
