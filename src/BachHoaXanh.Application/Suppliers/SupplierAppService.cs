using BachHoaXanh.Permissions;
using BachHoaXanh.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Suppliers
{
    public class SupplierAppService : ApplicationService, ISupplierAppService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public SupplierAppService(ISupplierRepository supplierRepository, IProductRepository productRepository )
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public async Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input)
        {
            var supplier = ObjectMapper.Map<CreateUpdateSupplierDto, Supplier>(input);
            await _supplierRepository.InsertAsync(supplier);
            return ObjectMapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var supplier = await _supplierRepository.FindAsync(id);
            var product = await _productRepository.AnyAsync(p => p.SupplierId == id);
            if (product == false)
            {
                await _supplierRepository.DeleteAsync(supplier);
                return true;
                
            }
            return false;

        }

        public async Task<PagedResultDto<SupplierDto>> GetListAsync(GetSupplierInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Supplier.Name);
            }
            var suppliers = await _supplierRepository.GetListAsync(
                   input.SkipCount,
                   input.MaxResultCount,
                   input.Sorting,
                   input.Filter
                );

            var totalCount = await _supplierRepository.GetCountAsync();
            return new PagedResultDto<SupplierDto>(
                    totalCount,
                    ObjectMapper.Map<List<Supplier>, List<SupplierDto>>(suppliers)
                );
        }

        public async Task<SupplierDto> GetSupplierAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetAsync(id);
            return ObjectMapper.Map<Supplier, SupplierDto>(supplier);
        }

        public async Task<SupplierDto> UpdateAsync(Guid id, CreateUpdateSupplierDto input)
        {
            var suplier = await _supplierRepository.FindAsync(id);
            suplier.Name=input.Name;
            suplier.Area=input.Area;
            suplier.Address=input.Address;
            suplier.PhoneNumber=input.PhoneNumber;

            await _supplierRepository.UpdateAsync(suplier);
            return ObjectMapper.Map<Supplier, SupplierDto>(suplier);
        }

    }
}
