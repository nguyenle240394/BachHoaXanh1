using BachHoaXanh.MongoDB;
using Volo.Abp.Modularity;

namespace BachHoaXanh;

[DependsOn(
    typeof(BachHoaXanhMongoDbTestModule)
    )]
public class BachHoaXanhDomainTestModule : AbpModule
{

}
