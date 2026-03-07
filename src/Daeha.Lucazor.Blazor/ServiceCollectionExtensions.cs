using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RnLucazor.Blazor;

/// <summary>
/// Extension methods for registering RnLucazor icon services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds RnLucazor icon services to the DI container.
    /// Registers <see cref="IIconProvider"/> and <see cref="ISvgRenderer"/>.
    /// </summary>
    public static IServiceCollection AddRnLucazor(this IServiceCollection services)
    {
        services.TryAddSingleton<IIconProvider, RnIconProvider>();
        services.TryAddSingleton<ISvgRenderer, StringSvgRenderer>();
        return services;
    }

    /// <summary>
    /// Adds RnLucazor icon services with a custom icon provider configuration.
    /// </summary>
    public static IServiceCollection AddRnLucazor(
        this IServiceCollection services,
        Action<RnIconProvider> configure)
    {
        services.AddSingleton<IIconProvider>(sp =>
        {
            var provider = new RnIconProvider();
            configure(provider);
            return provider;
        });
        services.TryAddSingleton<ISvgRenderer, StringSvgRenderer>();
        return services;
    }
}
