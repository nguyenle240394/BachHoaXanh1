using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BachHoaXanh.Staffs
{
    public class StaffAppService : ApplicationService, IStaffAppService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffAppService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<PagedResultDto<StaffDto>> GetListAsync(GetStaffInput input)
        {
            var staffs = await _staffRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );
            var staffDto = ObjectMapper.Map<List<Staff>, List<StaffDto>>(staffs);
            var total = await _staffRepository.GetCountAsync();
            return new PagedResultDto<StaffDto>(
                    total,
                    staffDto
                );
        }
    }
}
