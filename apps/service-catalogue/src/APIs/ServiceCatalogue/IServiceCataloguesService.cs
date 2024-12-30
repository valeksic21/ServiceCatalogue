using ServiceCatalogue_1.APIs.Common;
using ServiceCatalogue_1.APIs.Dtos;

namespace ServiceCatalogue_1.APIs;

public interface IServiceCataloguesService
{
    /// <summary>
    /// Create one ServiceCatalogue
    /// </summary>
    public Task<ServiceCatalogue> CreateServiceCatalogue(
        ServiceCatalogueCreateInput servicecatalogue
    );

    /// <summary>
    /// Delete one ServiceCatalogue
    /// </summary>
    public Task DeleteServiceCatalogue(ServiceCatalogueWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceCatalogues
    /// </summary>
    public Task<List<ServiceCatalogue>> ServiceCatalogues(
        ServiceCatalogueFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about ServiceCatalogue records
    /// </summary>
    public Task<MetadataDto> ServiceCataloguesMeta(ServiceCatalogueFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceCatalogue
    /// </summary>
    public Task<ServiceCatalogue> ServiceCatalogue(ServiceCatalogueWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceCatalogue
    /// </summary>
    public Task UpdateServiceCatalogue(
        ServiceCatalogueWhereUniqueInput uniqueId,
        ServiceCatalogueUpdateInput updateDto
    );
}
