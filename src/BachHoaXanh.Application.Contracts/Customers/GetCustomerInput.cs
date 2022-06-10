using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Customers
{
    public class GetCustomerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
