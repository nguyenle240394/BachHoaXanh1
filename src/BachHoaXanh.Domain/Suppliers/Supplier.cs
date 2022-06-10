using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace BachHoaXanh.Suppliers
{
    public class Supplier : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
