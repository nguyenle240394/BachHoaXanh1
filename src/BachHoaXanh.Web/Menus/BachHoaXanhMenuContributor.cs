using System.Threading.Tasks;
using BachHoaXanh.Localization;
using BachHoaXanh.MultiTenancy;
using BachHoaXanh.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace BachHoaXanh.Web.Menus;

public class BachHoaXanhMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        if (!MultiTenancyConsts.IsEnabled)
        {
            var administration = context.Menu.GetAdministration();
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        var l = context.GetLocalizer<BachHoaXanhResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BachHoaXanhMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        if (await context.IsGrantedAsync(BachHoaXanhPermissions.Customers.Default))
        { 
            context.Menu.AddItem(
                new ApplicationMenuItem(
                        "BachHoaXanh.Customers",
                        l["Menu:Customers"],
                        url: "/Customers"
                    )
            );
        }
        if (await context.IsGrantedAsync(BachHoaXanhPermissions.Customers.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(
                        "BachHoaXanh.Suppliers",
                        l["Menu:Suppliers"],
                        url: "/Suppliers"
                    )
            );
        }
        if (await context.IsGrantedAsync(BachHoaXanhPermissions.Products.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(
                        "BachHoaXanh.Producr",
                        l["Menu:Products"],
                        url: "/Products"
                    )
            );
        }
        if (await context.IsGrantedAsync(BachHoaXanhPermissions.Bills.Default))
        {
            context.Menu.AddItem(
                new ApplicationMenuItem(
                        "BachHoaXanh.Bill",
                        l["Menu:Bill"],
                        url: "/Bills"
                    )
            );
        }

        context.Menu.AddItem(
               new ApplicationMenuItem(
                       "BachHoaXanh.BillDetail",
                       l["Menu:BillDetail"],
                       url: "/BillDetails"
                   )
           );

        /*if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);*/
    }
}
