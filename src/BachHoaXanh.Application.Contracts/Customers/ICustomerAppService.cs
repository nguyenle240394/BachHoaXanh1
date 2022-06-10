using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BachHoaXanh.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerDto>> GetListAsync(GetCustomerInput input);
        Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input);
        Task<CustomerDto> GetCustomerAsync(Guid id);
    }
}
