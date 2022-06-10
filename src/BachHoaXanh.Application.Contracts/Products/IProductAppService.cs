using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace BachHoaXanh.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductInput input);
        Task<ProductDto> CreateAsync(CreateUpdateProductDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);
        Task<ProductDto> GetProductAsync(Guid id);
        Task<ListResultDto<SupplierLookup>> GetSupplierLookupAsync();
        Task<List<ProductDto>> GetListProductAsync();
    }
}
