using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace BachHoaXanh.Bills
{
    public interface IBillAppService : IApplicationService
    {
        Task<PagedResultDto<BillDto>> GetListAsync(GetBillInput input);
        Task<List<BillDto>> GetListBillAsync();
        Task<BillDto> CreateAsync(CreateUpdateBillDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<BillDto> UpdateAsync(Guid id,CreateUpdateBillDto input);
        Task<BillDto> GetBillAsync(Guid id);
        Task<ListResultDto<CustomerLookupDto>> GetCustomerLookupAsync();
        Task<ListResultDto<ProductLookupDto>> GetProductLookupAsync();
        Task<BillDto> GetLastIdAsync();
    }
}
