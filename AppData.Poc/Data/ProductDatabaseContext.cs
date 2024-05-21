using AppData.Poc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AppData.Poc.Data;

[ConnectionStringName("ProductDbConnectionString")]
public sealed class ProductDatabaseContext : AbpDbContext<ProductDatabaseContext>
{
    public ProductDatabaseContext(DbContextOptions<ProductDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSqlServer();
    }

    public DbSet<Product> Products { get; set; }
}