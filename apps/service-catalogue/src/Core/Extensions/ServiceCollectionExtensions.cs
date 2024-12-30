using ServiceCatalogue_1.APIs;

namespace ServiceCatalogue_1;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceCataloguesService, ServiceCataloguesService>();
    }
}
