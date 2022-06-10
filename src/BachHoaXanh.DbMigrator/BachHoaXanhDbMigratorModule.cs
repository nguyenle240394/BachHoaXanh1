using BachHoaXanh.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BachHoaXanh.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BachHoaXanhMongoDbModule),
    typeof(BachHoaXanhApplicationContractsModule)
    )]
public class BachHoaXanhDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
