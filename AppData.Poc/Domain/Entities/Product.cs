using Volo.Abp.Domain.Entities;

namespace AppData.Poc.Domain.Entities;

public class Product : Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public override object?[] GetKeys()
    {
        throw new NotImplementedException();
    }
}