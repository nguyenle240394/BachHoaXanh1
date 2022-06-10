using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Task<List<Customer>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter = null
            );
    }
}
