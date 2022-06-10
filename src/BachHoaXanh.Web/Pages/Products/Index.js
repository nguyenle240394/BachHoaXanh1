$(function () {
    var l = abp.localization.getResource('BachHoaXanh');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');

    var dataTable = $('#ProductTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(bachHoaXanh.products.product.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BachHoaXanh.Products.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BachHoaXanh.Products.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ProductDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        bachHoaXanh.products.product
                                            .delete(data.record.id)
                                            .then(function (data) {
                                                if (data) {
                                                    abp.notify.info(l('SuccessfullyDeleted'));
                                                    dataTable.ajax.reload();
                                                } else {
                                                    abp.message.error(l("NotifyDeleteBill"));
                                                }

                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Product'),
                    data: "name"
                },
                {
                    "orderable": false,
                    title: l('Supplier Name'),
                    data: "supplierName"
                },
                {
                    title: l('Unit Price'),
                    data: "unitPrice"
                },
                {
                    title: l('Unit'),
                    data: "unit"
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
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
