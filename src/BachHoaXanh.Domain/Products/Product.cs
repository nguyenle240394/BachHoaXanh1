using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BachHoaXanh.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
