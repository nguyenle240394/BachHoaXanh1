using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Bills
{
    public class ProductLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
