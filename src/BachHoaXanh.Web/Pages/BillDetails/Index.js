$(function () {
    var l = abp.localization.getResource('BachHoaXanh');
    /*var createModal = new abp.ModalManager(abp.appPath + 'Bills/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Bills/EditModal');*/
    /*var excel = new abp.ModalManager(abp.appPath + 'Bills/Excel');*/
    /*var index = new abp.ModalManager(abp.appPath + 'Bills/ExcelModal');*/

    var dataTable = $('#BillDetailTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(bachHoaXanh.billDetails.billDetail.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BachHoaXanh.Bills.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BachHoaXanh.BillDetails.Delete'),
                                    confirmMessage: function (data) {
                                        return l('BillDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        bachHoaXanh.bills.bill
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Customer'),
                    data: "customerName"
                },
                {
                    title: l('Product'),
                    data: "productName"
                },
                {
                    title: l('Quantity'),
                    data: "quantity"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })

    );
   /* createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewBillButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });*/
});
