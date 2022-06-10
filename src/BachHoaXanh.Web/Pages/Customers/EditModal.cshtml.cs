using BachHoaXanh.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages.Customers
{
    public class EditModalModel : BachHoaXanhPageModel
    {
        private readonly ICustomerAppService _customerAppService;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }
        public EditModalModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public async Task OnGetAsync()
        {
            var customerDto = await _customerAppService.GetCustomerAsync(Id);
            Customer = ObjectMapper.Map<CustomerDto, CreateUpdateCustomerDto>(customerDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.UpdateAsync(Id, Customer);
            return NoContent();
        }
    }
}
