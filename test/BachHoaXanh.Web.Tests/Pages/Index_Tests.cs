using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BachHoaXanh.Pages;

[Collection(BachHoaXanhTestConsts.CollectionDefinitionName)]
public class Index_Tests : BachHoaXanhWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
