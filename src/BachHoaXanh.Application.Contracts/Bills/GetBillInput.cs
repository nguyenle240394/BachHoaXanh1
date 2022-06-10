using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Bills
{
    public class GetBillInput : PagedAndSortedResultRequestDto
    {
        public int Filter { get; set; }
    }
}
