using System;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Products
{
    public class GetProductInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
