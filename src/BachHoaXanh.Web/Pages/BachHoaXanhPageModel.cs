using BachHoaXanh.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BachHoaXanh.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BachHoaXanhPageModel : AbpPageModel
{
    protected BachHoaXanhPageModel()
    {
        LocalizationResourceType = typeof(BachHoaXanhResource);
    }
}
