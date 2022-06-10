using BachHoaXanh.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BachHoaXanh.Permissions;

public class BachHoaXanhPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        /*var myGroup = context.AddGroup(BachHoaXanhPermissions.GroupName);*/
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BachHoaXanhPermissions.MyPermission1, L("Permission:MyPermission1"));
        var bachHoaXanhGroup = context.AddGroup(BachHoaXanhPermissions.GroupName, L("Permission:BachHoaXanh"));
        var customerPermission = bachHoaXanhGroup.AddPermission(BachHoaXanhPermissions.Customers.Default, L("Permission:Customers"));
        customerPermission.AddChild(BachHoaXanhPermissions.Customers.Create, L("Permission:Customers.Create"));
        customerPermission.AddChild(BachHoaXanhPermissions.Customers.Edit, L("Permission:Customers.Edit"));
        customerPermission.AddChild(BachHoaXanhPermissions.Customers.Delete, L("Permission:Customers.Delete"));

        var supplierPermission = bachHoaXanhGroup.AddPermission(BachHoaXanhPermissions.Suppliers.Default, L("Permission:Suppliers"));
        supplierPermission.AddChild(BachHoaXanhPermissions.Suppliers.Create, L("Permission:Suppliers.Create"));
        supplierPermission.AddChild(BachHoaXanhPermissions.Suppliers.Edit, L("Permission:Suppliers.Edit"));
        supplierPermission.AddChild(BachHoaXanhPermissions.Suppliers.Delete, L("Permission:Suppliers.Delete"));


        var productPermission = bachHoaXanhGroup.AddPermission(BachHoaXanhPermissions.Products.Default, L("Permission:Products"));
        productPermission.AddChild(BachHoaXanhPermissions.Products.Create, L("Permission:Products.Create"));
        productPermission.AddChild(BachHoaXanhPermissions.Products.Edit, L("Permission:Products.Edit"));
        productPermission.AddChild(BachHoaXanhPermissions.Products.Delete, L("Permission:Products.Delete"));


        var BillPermission = bachHoaXanhGroup.AddPermission(BachHoaXanhPermissions.Bills.Default, L("Permission:Bills"));
        BillPermission.AddChild(BachHoaXanhPermissions.Bills.Create, L("Permission:Bills.Create"));
        BillPermission.AddChild(BachHoaXanhPermissions.Bills.Edit, L("Permission:Bills.Edit"));
        BillPermission.AddChild(BachHoaXanhPermissions.Bills.Delete, L("Permission:Bills.Delete"));
        BillPermission.AddChild(BachHoaXanhPermissions.Bills.Excel, L("Permission:Bills.Excel"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BachHoaXanhResource>(name);
    }
}
