using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace BachHoaXanh;

public class BachHoaXanhWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<BachHoaXanhWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
