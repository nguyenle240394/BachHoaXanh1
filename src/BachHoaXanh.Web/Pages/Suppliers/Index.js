$(function () {
    var l = abp.localization.getResource('BachHoaXanh');
    var createModal = new abp.ModalManager(abp.appPath + 'Suppliers/CreataeModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Suppliers/EditModal');

    var dataTable = $('#SupplierTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(bachHoaXanh.suppliers.supplier.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BachHoaXanh.Suppliers.Edit'),
                                    action: function (data) {
                                        editModal.open({ Id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BachHoaXanh.Suppliers.Delete'),
                                    confirmMessage: function (data) {
                                        return l('SupplierDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        bachHoaXanh.suppliers.supplier
                                            .delete(data.record.id)
                                            .then(function (data) {
                                                if (data) {
                                                    abp.notify.info(l('Successful Deleted'));
                                                    dataTable.ajax.reload();
                                                } else {
                                                    abp.message.error(l("Delete product first"));
                                                }
                                                
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    "orderable": false,
                    title: l('Area'),
                    data: "area",
                },
                {
                    "orderable": false,
                    title: l('Phone Number'),
                    data: "phoneNumber",

                },
                {
                    title: l('Address'),
                    data: "address"
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


    $('#NewSupplierButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
