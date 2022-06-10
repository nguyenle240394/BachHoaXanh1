using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Suppliers
{
    public class SupplierDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
