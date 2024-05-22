using Volo.Abp.Domain.Entities;

namespace AppData.Poc.Domain.Entities;

public class Product : AggregateRoot<int>
{
    public string Name { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}