using BachHoaXanh.Suppliers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages.Suppliers
{
    public class CreataeModalModel : BachHoaXanhPageModel
    {
        private readonly ISupplierAppService _supplierAppService;

        [BindProperty]
        public CreateUpdateSupplierDto Supplier { get; set; }
        public CreataeModalModel(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }
        public void OnGet()
        {
            Supplier = new CreateUpdateSupplierDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _supplierAppService.CreateAsync(Supplier);
            return NoContent();
        }
    }
}
