using System;
using System.ComponentModel.DataAnnotations;

namespace BachHoaXanh.BillDetails
{
    public class CreateUpdateBillDetail
    {
        public Guid ProductId { get; set; }
        public Guid BillId { get; set; }
        [Range(1,1000)]
        public int Quantity { get; set; }
    }
}
