using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.BillDetails
{
    public class GetBillDetailInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
