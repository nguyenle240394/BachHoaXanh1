using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Staffs
{
    public interface IStaffRepository : IRepository<Staff, Guid>
    {
        Task<List<Staff>> GetListAsync(
                 int skipCount,
                 int maxResultCount,
                 string sorting,
                 int filter
             );
    }
}
