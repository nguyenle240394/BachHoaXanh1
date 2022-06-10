using BachHoaXanh.Suppliers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BachHoaXanh.Web.Pages.Suppliers
{
    public class EditModalModel : BachHoaXanhPageModel
    {
        private readonly ISupplierAppService _supplierAppService;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateSupplierDto Supplier { get; set; }
        public EditModalModel(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }
        public async Task OnGetAsync()
        {
            var supplierDto = await _supplierAppService.GetSupplierAsync(Id);
            Supplier = ObjectMapper.Map<SupplierDto, CreateUpdateSupplierDto>(supplierDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _supplierAppService.UpdateAsync(Id, Supplier);
            return NoContent();
        }
    }
}
