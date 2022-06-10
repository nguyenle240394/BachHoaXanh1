using BachHoaXanh.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.Products
{
    public class MongoDbProductRepository : MongoDbRepository<BachHoaXanhMongoDbContext, Product, Guid>, IProductRepository
    {
        public MongoDbProductRepository(IMongoDbContextProvider<BachHoaXanhMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Product>> GetListAsync(int SkipCount, int maxResultCount, string sorting, string filter)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Product, IMongoQueryable<Product>>(
                    !filter.IsNullOrWhiteSpace(),
                    product => product.Name.Contains(filter)
                ).OrderBy(sorting)
                .As<IMongoQueryable<Product>>()
                .Skip(SkipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
