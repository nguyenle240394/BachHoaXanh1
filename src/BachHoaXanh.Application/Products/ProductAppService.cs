using BachHoaXanh.BillDetails;
using BachHoaXanh.Bills;
using BachHoaXanh.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Products
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IBillDetailRepository _billDetailRepository;

        public ProductAppService(IProductRepository productRepository, ISupplierRepository supplierRepository, IBillDetailRepository billDetailRepository )
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _billDetailRepository = billDetailRepository;
        }
        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
            await _productRepository.InsertAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepository.FindAsync(id);
            var billDetail = await _billDetailRepository.AnyAsync(x => x.ProductId==id);
            if (billDetail)
            {
                return false;
            }
            await _productRepository.DeleteAsync(product);
            return true;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductInput input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Product.Name);
            }
            var products = await _productRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
                );

            var prodcutDtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
            var supplierDictionry = await GetSupplierDictionaryAsync(products);
            prodcutDtos.ForEach(productDto => productDto.SupplierName = supplierDictionry[productDto.SupplierId].Name);
            var totalCount = await _productRepository.GetCountAsync();
            return new PagedResultDto<ProductDto>(
                    totalCount,
                    prodcutDtos
                );
        }

        public async Task<ProductDto> GetProductAsync(Guid id)
        {
            var product = await _productRepository.FindAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ListResultDto<SupplierLookup>> GetSupplierLookupAsync()
        {
            var suppliers = await _supplierRepository.GetListAsync();
            return new ListResultDto<SupplierLookup>(
                    ObjectMapper.Map<List<Supplier>, List<SupplierLookup>>(suppliers)
                );
        }

        private async Task<Dictionary<Guid, Supplier>> GetSupplierDictionaryAsync(List<Product> products)
        {
            var supplierIds = products
                .Select(p => p.SupplierId)
                .Distinct()
                .ToArray();

            var queryable = await _supplierRepository.GetQueryableAsync();
            var suppliers = await AsyncExecuter.ToListAsync(queryable.Where(s => supplierIds.Contains(s.Id)));
            return suppliers.ToDictionary(x => x.Id, x => x);
        }

        public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.FindAsync(id);
            product.SupplierId = input.SupplierId;
            product.Name=input.Name;
            product.UnitPrice=input.UnitPrice;
            product.Unit=input.Unit;

            await _productRepository.UpdateAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
            
        }

        public async Task<List<ProductDto>> GetListProductAsync()
        {
            var products = await _productRepository.GetListAsync();
            return ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
        }
    }
}
