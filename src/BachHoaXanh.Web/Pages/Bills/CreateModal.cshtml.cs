using BachHoaXanh.BillDetails;
using BachHoaXanh.Bills;
using BachHoaXanh.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BachHoaXanh.Web.Pages.Bills
{
    public class CreateModalModel : BachHoaXanhPageModel
    {
        private readonly IBillAppService _billAppService;
        private readonly BillDetailAppService _billDetailAppService;
        private readonly ProductAppService _productAppService;

        [BindProperty]
        public CreateBillViewModal Bill { get; set; }
        public List<SelectListItem> Customers { get; set; }
        /*public List<SelectListItem> Products { get; set; }*/
        public List<ProductDto> Products { get; set; }
        public CreateModalModel(IBillAppService billAppService, BillDetailAppService billDetailAppService, ProductAppService productAppService)
        {
            _billAppService = billAppService;
            _billDetailAppService = billDetailAppService;
            _productAppService = productAppService;
        }   
        public async Task OnGetAsync()
        {
            Bill = new CreateBillViewModal();
            var customerLookup = await _billAppService.GetCustomerLookupAsync();
            Customers = customerLookup.Items
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                .ToList();


            /* Bill = new CreateUpdateBillDto();
             var customerLookup = await _billAppService.GetCustomerLookup();
             Customers = customerLookup.Items
                 .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                 .ToList();*/

            Products = await _productAppService.GetListProductAsync();
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var billdto = ObjectMapper.Map<CreateBillViewModal, CreateUpdateBillDto>(Bill);
            await _billAppService.CreateAsync(
                    billdto
                );

            /*var billdtoLast = await _billAppService.GetLastIdAsync();
            await _billDetailAppService.CreateBillDetailAsync(billdtoLast.Id, Bill.ProductId);*/

            /*return NoContent();*/
            return RedirectToAction("Index", "Bills");
        }

        public string Thongbao;
        public void OnPostAddproduct(int id)
        {
            Thongbao = "Gọi OnPostSoanthao";
        }

        public class CreateBillViewModal
        {
            [SelectItems(nameof(Customers))]
            [DisplayName("Customer")]
            public Guid CustomerId { get; set; }

            /*[SelectItems(nameof(Products))]
            [DisplayName("Product")]
            public List<Guid> ProductId { get; set; }*/
        }
    }
}
                                  