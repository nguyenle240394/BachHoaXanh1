using BachHoaXanh.Bills;
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

namespace BachHoaXanh.Web.Pages.Bills
{
    public class EditModalModel : BachHoaXanhPageModel
    {
        private readonly IBillAppService _billAppService;

        [BindProperty]
        public EditBillViewModal Bill { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Products { get; set; }
        public EditModalModel(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var billDto = await _billAppService.GetBillAsync(id);
            Bill = ObjectMapper.Map<BillDto, EditBillViewModal>(billDto);
            var customerLookup = await _billAppService.GetCustomerLookupAsync();
            Customers = customerLookup.Items
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                .ToList();

            /*var productLookup = await _billAppService.GetCustomerLookupAsync();
            Products = productLookup.Items
                .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                .ToList();*/
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _billAppService.UpdateAsync(
                    Bill.Id,
                    ObjectMapper.Map<EditBillViewModal, CreateUpdateBillDto>(Bill)
                );
            return NoContent();
        }
        public class EditBillViewModal
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [SelectItems(nameof(Customers))]
            [DisplayName("Customer")]
            public Guid CustomerId { get; set; }
/*
            [SelectItems(nameof(Products))]
            [DisplayName("Product")]
            public List<Guid> ProductId { get; set; }*/
        }
    }
}
