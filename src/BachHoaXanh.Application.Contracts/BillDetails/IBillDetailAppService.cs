using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BachHoaXanh.BillDetails
{
    public interface IBillDetailAppService : IApplicationService
    {
        Task<PagedResultDto<BillDetailDto>> GetListAsync(GetBillDetailInput input);
        Task<BillDetailDto> CreateAsync(CreateUpdateBillDetail input);
        Task<bool> DeleteAsync(Guid id);
        Task<BillDetailDto> UpdateAsync(Guid id, CreateUpdateBillDetail input);
        Task<List<BillDetailDto>> CreateBillDetailAsync(Guid billId, List<Guid> productIds);
    }
}
