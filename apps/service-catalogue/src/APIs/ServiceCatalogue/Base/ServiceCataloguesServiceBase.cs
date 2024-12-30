using Microsoft.EntityFrameworkCore;
using ServiceCatalogue_1.APIs;
using ServiceCatalogue_1.APIs.Common;
using ServiceCatalogue_1.APIs.Dtos;
using ServiceCatalogue_1.APIs.Errors;
using ServiceCatalogue_1.APIs.Extensions;
using ServiceCatalogue_1.Infrastructure;
using ServiceCatalogue_1.Infrastructure.Models;

namespace ServiceCatalogue_1.APIs;

public abstract class ServiceCataloguesServiceBase : IServiceCataloguesService
{
    protected readonly ServiceCatalogue_1DbContext _context;

    public ServiceCataloguesServiceBase(ServiceCatalogue_1DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceCatalogue
    /// </summary>
    public async Task<ServiceCatalogue> CreateServiceCatalogue(
        ServiceCatalogueCreateInput createDto
    )
    {
        var serviceCatalogue = new ServiceCatalogueDbModel
        {
            Code = createDto.Code,
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceCatalogue.Id = createDto.Id.Value;
        }

        _context.ServiceCatalogues.Add(serviceCatalogue);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceCatalogueDbModel>(serviceCatalogue.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceCatalogue
    /// </summary>
    public async Task DeleteServiceCatalogue(ServiceCatalogueWhereUniqueInput uniqueId)
    {
        var serviceCatalogue = await _context.ServiceCatalogues.FindAsync(uniqueId.Id);
        if (serviceCatalogue == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceCatalogues.Remove(serviceCatalogue);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceCatalogues
    /// </summary>
    public async Task<List<ServiceCatalogue>> ServiceCatalogues(
        ServiceCatalogueFindManyArgs findManyArgs
    )
    {
        var serviceCatalogues = await _context
            .ServiceCatalogues.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceCatalogues.ConvertAll(serviceCatalogue => serviceCatalogue.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceCatalogue records
    /// </summary>
    public async Task<MetadataDto> ServiceCataloguesMeta(ServiceCatalogueFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceCatalogues.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceCatalogue
    /// </summary>
    public async Task<ServiceCatalogue> ServiceCatalogue(ServiceCatalogueWhereUniqueInput uniqueId)
    {
        var serviceCatalogues = await this.ServiceCatalogues(
            new ServiceCatalogueFindManyArgs
            {
                Where = new ServiceCatalogueWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceCatalogue = serviceCatalogues.FirstOrDefault();
        if (serviceCatalogue == null)
        {
            throw new NotFoundException();
        }

        return serviceCatalogue;
    }

    /// <summary>
    /// Update one ServiceCatalogue
    /// </summary>
    public async Task UpdateServiceCatalogue(
        ServiceCatalogueWhereUniqueInput uniqueId,
        ServiceCatalogueUpdateInput updateDto
    )
    {
        var serviceCatalogue = updateDto.ToModel(uniqueId);

        _context.Entry(serviceCatalogue).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceCatalogues.Any(e => e.Id == serviceCatalogue.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
