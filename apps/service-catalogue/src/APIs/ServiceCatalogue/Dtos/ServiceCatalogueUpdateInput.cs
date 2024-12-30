namespace ServiceCatalogue_1.APIs.Dtos;

public class ServiceCatalogueUpdateInput
{
    public string? Code { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Description { get; set; }

    public long? Id { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
