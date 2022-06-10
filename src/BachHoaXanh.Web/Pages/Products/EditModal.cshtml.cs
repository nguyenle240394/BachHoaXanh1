using BachHoaXanh.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BachHoaXanh.Web.Pages.Products
{
    public class EditModalModel : BachHoaXanhPageModel
    {
        private readonly IProductAppService _productAppService;

        [BindProperty]
        public EditProductViewModal Product { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public EditModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task OnGetAsync(Guid Id)
        {
            var productDto = await _productAppService.GetProductAsync(Id);
            Product = ObjectMapper.Map<ProductDto, EditProductViewModal>(productDto);
            var supplierLookup = await _productAppService.GetSupplierLookupAsync();
            Suppliers = supplierLookup.Items
                .Select(s => new SelectListItem(s.Name,s.Id.ToString()))
                .ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.UpdateAsync(
                    Product.Id,
                    ObjectMapper.Map<EditProductViewModal, CreateUpdateProductDto>(Product)
                );
            return NoContent();
        }

        public class EditProductViewModal
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(Suppliers))]
            [DisplayName("Supplier")]
            public Guid SupplierId { get; set; }

            [Required]
            [StringLength(32)]
            [DisplayName("Product")]
            public string Name { get; set; }
            [Required]
            public float UnitPrice { get; set; }
            [Required]
            public string Unit { get; set; }
        }

    }
}
