using BachHoaXanh.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages.Customers
{
    public class CreateModalModel : BachHoaXanhPageModel
    {
        private readonly ICustomerAppService _customerAppService;

        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }
        public CreateModalModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public void OnGet()
        {
            Customer = new CreateUpdateCustomerDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.CreateAsync(Customer);
            return NoContent();
        }
    }
}
