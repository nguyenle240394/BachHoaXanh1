using BachHoaXanh.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.Staffs
{
    public class MongoDbStaffRepository : MongoDbRepository<BachHoaXanhMongoDbContext, Staff, Guid>, IStaffRepository
    {
        public MongoDbStaffRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Staff>> GetListAsync(int skipCount, int maxResultCount, string sorting, int filter)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                /*.OrderBy(sorting)
                .As<IMongoQueryable<Bill>>()
                .Skip(skipCount)
                .Take(maxResultCount)*/
                .ToListAsync();
        }
    }
}
