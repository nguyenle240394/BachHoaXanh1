using AutoMapper;
using BachHoaXanh.BillDetails;
using BachHoaXanh.Bills;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using BachHoaXanh.Staffs;
using BachHoaXanh.Suppliers;

namespace BachHoaXanh;

public class BachHoaXanhApplicationAutoMapperProfile : Profile
{
    public BachHoaXanhApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<Customer, CustomerDto>();


        CreateMap<Customer, CustomerLookupDto>();
        CreateMap<Product, ProductLookupDto>();


        CreateMap<CreateUpdateSupplierDto, Supplier>();
        CreateMap<Supplier, SupplierDto>();
        CreateMap<Supplier, SupplierLookup>();

        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<Product, ProductDto>();

        CreateMap<CreateUpdateBillDto, Bill>();
        CreateMap<Bill, BillDto>();

        CreateMap<Staff, StaffDto>();

        CreateMap<BillDetail, BillDetailDto>();
        CreateMap<CreateUpdateBillDetail, BillDetail>();
        CreateMap<BillDetail, BillDetailDto>();

    }
}
