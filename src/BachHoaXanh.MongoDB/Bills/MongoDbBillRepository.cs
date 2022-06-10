using BachHoaXanh.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.Bills
{
    public class MongoDbBillRepository : MongoDbRepository<BachHoaXanhMongoDbContext, Bill, Guid>,IBillRepository
    {
        public MongoDbBillRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<List<Bill>> GetListAsync(int skipCount, int maxResultCount, string sorting, int filter)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .OrderByDescending(x => x.CreationTime)
                /*.OrderBy(sorting)*/
                .As<IMongoQueryable<Bill>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
