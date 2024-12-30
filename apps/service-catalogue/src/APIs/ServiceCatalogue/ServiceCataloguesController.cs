using Microsoft.AspNetCore.Mvc;

namespace ServiceCatalogue_1.APIs;

[ApiController()]
public class ServiceCataloguesController : ServiceCataloguesControllerBase
{
    public ServiceCataloguesController(IServiceCataloguesService service)
        : base(service) { }
}
