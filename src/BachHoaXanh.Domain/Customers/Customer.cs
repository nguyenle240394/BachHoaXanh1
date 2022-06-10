using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BachHoaXanh.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
