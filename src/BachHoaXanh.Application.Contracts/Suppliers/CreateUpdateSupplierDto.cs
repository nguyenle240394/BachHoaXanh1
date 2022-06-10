using System.ComponentModel.DataAnnotations;


namespace BachHoaXanh.Suppliers
{
    public class CreateUpdateSupplierDto
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        public string Area { get; set; }
        [Required]
        [StringLength(120)]
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
