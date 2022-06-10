using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages;

public class IndexModel : BachHoaXanhPageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        var currentUser = CurrentUser.Id;
        if (currentUser==null)
        {
            return Redirect("/Account/Login");
        }
        return Page();
    }
}
