using Volo.Abp.Modularity;

namespace BachHoaXanh;

[DependsOn(
    typeof(BachHoaXanhApplicationModule),
    typeof(BachHoaXanhDomainTestModule)
    )]
public class BachHoaXanhApplicationTestModule : AbpModule
{

}
