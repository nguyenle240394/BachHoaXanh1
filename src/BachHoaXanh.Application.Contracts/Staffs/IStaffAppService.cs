using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BachHoaXanh.Staffs
{
    public interface IStaffAppService : IApplicationService
    {
        Task<PagedResultDto<StaffDto>> GetListAsync(GetStaffInput input);
    }
}
