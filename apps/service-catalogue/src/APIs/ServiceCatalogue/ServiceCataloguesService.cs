using ServiceCatalogue_1.Infrastructure;

namespace ServiceCatalogue_1.APIs;

public class ServiceCataloguesService : ServiceCataloguesServiceBase
{
    public ServiceCataloguesService(ServiceCatalogue_1DbContext context)
        : base(context) { }
}
