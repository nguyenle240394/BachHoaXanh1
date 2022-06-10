using AutoMapper;
using BachHoaXanh.Bills;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using BachHoaXanh.Suppliers;

namespace BachHoaXanh.Web;

public class BachHoaXanhWebAutoMapperProfile : Profile
{
    public BachHoaXanhWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CustomerDto, CreateUpdateCustomerDto>();
        CreateMap<SupplierDto, CreateUpdateSupplierDto>();

        CreateMap<Pages.Products.CreateModalModel.CreateProductViewModal, CreateUpdateProductDto>();
        CreateMap<Pages.Bills.CreateModalModel.CreateBillViewModal, CreateUpdateBillDto>();

        CreateMap<ProductDto, Pages.Products.EditModalModel.EditProductViewModal>();
        CreateMap<Pages.Products.EditModalModel.EditProductViewModal, CreateUpdateProductDto>();
        CreateMap<BillDto, Pages.Bills.EditModalModel.EditBillViewModal>();
        CreateMap<Pages.Bills.EditModalModel.EditBillViewModal, CreateUpdateBillDto>();
    }
}
