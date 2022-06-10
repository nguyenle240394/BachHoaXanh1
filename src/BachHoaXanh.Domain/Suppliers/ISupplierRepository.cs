using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Suppliers
{
    public interface ISupplierRepository : IRepository<Supplier, Guid>
    {
        Task<List<Supplier>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter = null
            );
    }
}
