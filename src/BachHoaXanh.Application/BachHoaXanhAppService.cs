using System;
using System.Collections.Generic;
using System.Text;
using BachHoaXanh.Localization;
using Volo.Abp.Application.Services;

namespace BachHoaXanh;

/* Inherit your application services from this class.
 */
public abstract class BachHoaXanhAppService : ApplicationService
{
    protected BachHoaXanhAppService()
    {
        LocalizationResource = typeof(BachHoaXanhResource);
    }
}
