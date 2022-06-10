using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Staffs
{
    public class StaffDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
