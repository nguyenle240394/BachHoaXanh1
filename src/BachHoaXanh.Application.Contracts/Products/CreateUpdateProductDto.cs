using System;
using System.ComponentModel.DataAnnotations;

namespace BachHoaXanh.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        public Guid SupplierId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [Range(1,10000)]
        public float UnitPrice { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
