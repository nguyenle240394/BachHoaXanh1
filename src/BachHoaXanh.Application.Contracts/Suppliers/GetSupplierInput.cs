using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Suppliers
{
    public class GetSupplierInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
