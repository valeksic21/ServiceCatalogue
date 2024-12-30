using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceCatalogue_1.Infrastructure.Models;

namespace ServiceCatalogue_1.Infrastructure;

public class ServiceCatalogue_1DbContext : IdentityDbContext<IdentityUser>
{
    public ServiceCatalogue_1DbContext(DbContextOptions<ServiceCatalogue_1DbContext> options)
        : base(options) { }

    public DbSet<ServiceCatalogueDbModel> ServiceCatalogues { get; set; }
}
