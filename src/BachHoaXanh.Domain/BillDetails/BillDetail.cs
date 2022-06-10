using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BachHoaXanh.BillDetails
{
    public class BillDetail: AuditedAggregateRoot<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid BillId { get; set; }
        public int Quantity { get; set; }
    }
}
