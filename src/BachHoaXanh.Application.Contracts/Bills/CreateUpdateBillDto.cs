using System;
using System.ComponentModel.DataAnnotations;

namespace BachHoaXanh.Bills
{
    public class CreateUpdateBillDto
    {
        public Guid CustomerId { get; set; }
    }
}
