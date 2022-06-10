using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BachHoaXanh.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; } = DateTime.Now;
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
