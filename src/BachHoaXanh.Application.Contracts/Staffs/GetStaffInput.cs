using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Staffs
{
    public class GetStaffInput : PagedAndSortedResultRequestDto
    {
        public int Filter { get; set; }
    }
}
