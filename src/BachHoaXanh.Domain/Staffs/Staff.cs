using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BachHoaXanh.Staffs
{
    public class Staff : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
