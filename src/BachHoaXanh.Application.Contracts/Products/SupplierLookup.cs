using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Products
{
    public class SupplierLookup : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
