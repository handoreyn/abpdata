using AppData.Poc.Data;
using AppData.Poc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;

namespace AppData.Poc;

public class App
{

    private readonly IRepository<Product, int> _repository;
    public App(IRepository<Product, int> repository)
    {
        _repository = repository;
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var products = await _repository.ToListAsync(cancellationToken);

        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
        }
    }
}