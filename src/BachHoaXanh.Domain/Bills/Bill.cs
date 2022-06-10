using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BachHoaXanh.Bills
{
    public class Bill : AuditedAggregateRoot<Guid>
    {
        public Guid CustomerId { get; set; }
    }
}
