using BachHoaXanh.Bills;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using BachHoaXanh.Suppliers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BachHoaXanh
{
    public class BachHoaXanhDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBillRepository _billRepository;

        public BachHoaXanhDataSeederContributor(
            ICustomerRepository customerRepository, 
            ISupplierRepository supplierRepository, 
            IProductRepository productRepository,
            IBillRepository billRepository)
        {
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _billRepository = billRepository;
            
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _supplierRepository.GetCountAsync()<=0)
            {
                var HL = await _supplierRepository.InsertAsync(
                        new Supplier
                        {
                            Name = "Hoàng Long",
                            Area = "Việt Nam",
                            Address = "Phường 12, Quận 9",
                            PhoneNumber = "123459999"
                        }
                    );

               var TH = await _supplierRepository.InsertAsync(
                        new Supplier
                        {
                            Name = "Thiên Hạ",
                            Area = "Việt Nam",
                            Address = "Phường 3, Quận 10",
                            PhoneNumber = "999988888"
                        }
                    );
            }
        }
    }
}
