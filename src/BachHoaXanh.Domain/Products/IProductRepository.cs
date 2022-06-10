using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BachHoaXanh.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<List<Product>> GetListAsync(
                int SkipCount,
                int maxResultCount,
                string sorting,
                string filter
            );
    }
}
