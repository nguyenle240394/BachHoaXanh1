using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace BachHoaXanh.MongoDB;

[DependsOn(
    typeof(BachHoaXanhTestBaseModule),
    typeof(BachHoaXanhMongoDbModule)
    )]
public class BachHoaXanhMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = BachHoaXanhMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
