using BachHoaXanh.BillDetails;
using BachHoaXanh.Bills;
using BachHoaXanh.Customers;
using BachHoaXanh.Products;
using BachHoaXanh.Staffs;
using BachHoaXanh.Suppliers;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace BachHoaXanh.MongoDB;

[ConnectionStringName("Default")]
public class BachHoaXanhMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<Customer> Customers => Collection<Customer>();

    public IMongoCollection<Supplier> Suppliers => Collection<Supplier>();

    public IMongoCollection<Product> Products => Collection<Product>();

    public IMongoCollection<Bill> Bills => Collection<Bill>();
    public IMongoCollection<Staff> Staffs => Collection<Staff>();

    public IMongoCollection<BillDetail> BillDetails => Collection<BillDetail>();
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
