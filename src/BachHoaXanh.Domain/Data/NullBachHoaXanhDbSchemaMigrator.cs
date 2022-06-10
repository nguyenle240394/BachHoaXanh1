using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BachHoaXanh.Data;

/* This is used if database provider does't define
 * IBachHoaXanhDbSchemaMigrator implementation.
 */
public class NullBachHoaXanhDbSchemaMigrator : IBachHoaXanhDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
