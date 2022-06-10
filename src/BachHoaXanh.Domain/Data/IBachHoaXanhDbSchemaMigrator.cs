using System.Threading.Tasks;

namespace BachHoaXanh.Data;

public interface IBachHoaXanhDbSchemaMigrator
{
    Task MigrateAsync();
}
