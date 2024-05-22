using AppData.Poc.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace AppData.Poc;
[DependsOn(
    typeof(BookStoreEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
)]
public class ProductModule : AbpModule
{
    private SqlConnection? _sqlServerConnection;
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // ConfigureInMemorySqlite(context.Services);
        ConfigureSqlServer(context.Services);
        context.Services.AddTransient<App>();
    }
    
    private void ConfigureSqlServer(IServiceCollection services)
    {
        _sqlServerConnection = CreateDatabaseAndGetConnection();

        services.Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(context =>
            {
                context.DbContextOptions.UseSqlServer(_sqlServerConnection);
            });
        });
    }
    
    
    private static SqlConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqlConnection("Server=localhost; Database=Products; User=sa; Password=Fr00t_L00pth; Trust Server Certificate=True;");
        connection.Open();

        var options = new DbContextOptionsBuilder<ProductDatabaseContext>()
            .UseSqlServer(connection)
            .Options;


        return connection;
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        Console.WriteLine("hi");
        base.OnApplicationInitialization(context);
    }
}