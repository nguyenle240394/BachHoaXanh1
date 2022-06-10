using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Bills
{
    public class BillDto : AuditedEntityDto<Guid>
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<Guid> BillDetailIDs { get; set; }
        /*public List<Guid> ProductIDs { get; set; }*/
        public List<string> ProductNames { get; set; }
    }
}
