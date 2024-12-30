using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceCatalogue_1.APIs;
using ServiceCatalogue_1.APIs.Common;
using ServiceCatalogue_1.APIs.Dtos;
using ServiceCatalogue_1.APIs.Errors;

namespace ServiceCatalogue_1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ServiceCataloguesControllerBase : ControllerBase
{
    protected readonly IServiceCataloguesService _service;

    public ServiceCataloguesControllerBase(IServiceCataloguesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ServiceCatalogue
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceCatalogue>> CreateServiceCatalogue(
        ServiceCatalogueCreateInput input
    )
    {
        var serviceCatalogue = await _service.CreateServiceCatalogue(input);

        return CreatedAtAction(
            nameof(ServiceCatalogue),
            new { id = serviceCatalogue.Id },
            serviceCatalogue
        );
    }

    /// <summary>
    /// Delete one ServiceCatalogue
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteServiceCatalogue(
        [FromRoute()] ServiceCatalogueWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteServiceCatalogue(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ServiceCatalogues
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<ServiceCatalogue>>> ServiceCatalogues(
        [FromQuery()] ServiceCatalogueFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceCatalogues(filter));
    }

    /// <summary>
    /// Meta data about ServiceCatalogue records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ServiceCataloguesMeta(
        [FromQuery()] ServiceCatalogueFindManyArgs filter
    )
    {
        return Ok(await _service.ServiceCataloguesMeta(filter));
    }

    /// <summary>
    /// Get one ServiceCatalogue
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<ServiceCatalogue>> ServiceCatalogue(
        [FromRoute()] ServiceCatalogueWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ServiceCatalogue(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ServiceCatalogue
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateServiceCatalogue(
        [FromRoute()] ServiceCatalogueWhereUniqueInput uniqueId,
        [FromQuery()] ServiceCatalogueUpdateInput serviceCatalogueUpdateDto
    )
    {
        try
        {
            await _service.UpdateServiceCatalogue(uniqueId, serviceCatalogueUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
