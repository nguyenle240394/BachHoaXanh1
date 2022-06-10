using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
