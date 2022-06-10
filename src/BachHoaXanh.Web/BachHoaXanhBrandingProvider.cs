using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace BachHoaXanh.Web;

[Dependency(ReplaceServices = true)]
public class BachHoaXanhBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BachHoaXanh";
}
