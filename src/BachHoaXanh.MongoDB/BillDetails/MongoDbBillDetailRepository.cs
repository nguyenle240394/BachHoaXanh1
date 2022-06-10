using BachHoaXanh.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.BillDetails
{
    public class MongoDbBillDetailRepository : MongoDbRepository<BachHoaXanhMongoDbContext, BillDetail, Guid>, IBillDetailRepository
    {
        public MongoDbBillDetailRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<BillDetail> GetBillDetail(Guid bill, Guid productId)
        {
            var billdetail = new BillDetail();
            billdetail.BillId = bill;
            billdetail.ProductId = productId;
            return billdetail;
        }

        public async Task<List<BillDetail>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .OrderByDescending(x => x.CreationTime)
                .As<IMongoQueryable<BillDetail>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
