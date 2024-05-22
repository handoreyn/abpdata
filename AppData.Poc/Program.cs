using AppData.Poc;
using Volo.Abp;

using var application = AbpApplicationFactory.Create<ProductModule>();

application.Initialize();
