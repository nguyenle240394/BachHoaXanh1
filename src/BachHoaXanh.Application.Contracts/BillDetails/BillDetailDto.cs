using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.BillDetails
{
    public class BillDetailDto : AuditedEntityDto<Guid>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid BillId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
    }
}
