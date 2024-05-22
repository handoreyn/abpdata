using AppData.Poc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AppData.Poc.Data;

public class ProductDatabaseContext : AbpDbContext<ProductDatabaseContext>
{
    public ProductDatabaseContext(DbContextOptions<ProductDatabaseContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; init; }
}