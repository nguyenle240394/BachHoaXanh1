using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Bills
{
    public interface IBillRepository : IRepository<Bill, Guid>
    {
        Task<List<Bill>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                int filter
            );
    }
}
