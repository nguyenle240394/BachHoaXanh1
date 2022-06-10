using BachHoaXanh.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.Suppliers
{
    public class MongdoDbSupplierRepository : MongoDbRepository<BachHoaXanhMongoDbContext, Supplier, Guid>, ISupplierRepository
    {
        public MongdoDbSupplierRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Supplier>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Supplier, IMongoQueryable<Supplier>>(
                    !filter.IsNullOrWhiteSpace(),
                    supplier => supplier.Name.Contains(filter)
                ).OrderBy(sorting)
                .As<IMongoQueryable<Supplier>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
