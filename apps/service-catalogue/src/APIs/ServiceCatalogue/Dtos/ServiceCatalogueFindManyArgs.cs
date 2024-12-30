using Microsoft.AspNetCore.Mvc;
using ServiceCatalogue_1.APIs.Common;
using ServiceCatalogue_1.Infrastructure.Models;

namespace ServiceCatalogue_1.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ServiceCatalogueFindManyArgs
    : FindManyInput<ServiceCatalogue, ServiceCatalogueWhereInput> { }
