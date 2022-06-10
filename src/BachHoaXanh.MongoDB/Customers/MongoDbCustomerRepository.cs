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

namespace BachHoaXanh.Customers
{
    public class MongoDbCustomerRepository : MongoDbRepository<BachHoaXanhMongoDbContext, Customer, Guid>, ICustomerRepository
    {
        

        public MongoDbCustomerRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<Customer>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var quyeryable = await GetMongoQueryableAsync();
            return await quyeryable
                .WhereIf<Customer, IMongoQueryable<Customer>>(
                    !filter.IsNullOrWhiteSpace(),
                    customer => customer.Name.Contains(filter)
                ).OrderByDescending(x => x.CreationTime)
                .As<IMongoQueryable<Customer>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
