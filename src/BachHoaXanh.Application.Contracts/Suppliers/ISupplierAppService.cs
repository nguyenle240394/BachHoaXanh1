using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Suppliers
{
    public interface ISupplierAppService : IApplicationService
    {
        Task<PagedResultDto<SupplierDto>> GetListAsync(GetSupplierInput input);
        Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<SupplierDto> UpdateAsync(Guid id, CreateUpdateSupplierDto input);
        Task<SupplierDto> GetSupplierAsync(Guid id);
    }
}
