using BachHoaXanh.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BachHoaXanh.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BachHoaXanhController : AbpControllerBase
{
    protected BachHoaXanhController()
    {
        LocalizationResource = typeof(BachHoaXanhResource);
    }
}
