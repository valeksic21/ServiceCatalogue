using ServiceCatalogue_1.APIs.Dtos;
using ServiceCatalogue_1.Infrastructure.Models;

namespace ServiceCatalogue_1.APIs.Extensions;

public static class ServiceCataloguesExtensions
{
    public static ServiceCatalogue ToDto(this ServiceCatalogueDbModel model)
    {
        return new ServiceCatalogue
        {
            Code = model.Code,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ServiceCatalogueDbModel ToModel(
        this ServiceCatalogueUpdateInput updateDto,
        ServiceCatalogueWhereUniqueInput uniqueId
    )
    {
        var serviceCatalogue = new ServiceCatalogueDbModel
        {
            Id = uniqueId.Id,
            Code = updateDto.Code,
            Description = updateDto.Description,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            serviceCatalogue.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            serviceCatalogue.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return serviceCatalogue;
    }
}
