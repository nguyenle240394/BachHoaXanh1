using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.BillDetails
{
    public interface IBillDetailRepository : IRepository<BillDetail, Guid>
    {
        Task<BillDetail> GetBillDetail(Guid bill, Guid productId);
        Task<List<BillDetail>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter = null
            );
    }
}
