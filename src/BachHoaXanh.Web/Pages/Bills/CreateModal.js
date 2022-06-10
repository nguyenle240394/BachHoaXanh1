$(function () {
    var l = abp.localization.getResource('BachHoaXanh');

    var dataTable = $('#listProduct').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(bachHoaXanh.products.product.getList),
            columnDefs: [
                {
                    title: l('Product'),
                    data: "name"
                },
                {
                    title: l('Unnit Price'),
                    data: "unitPrice"
                },
                {
                    /*get id từ server*/
                    data: "id",
                    /*thực hiện tạo 1 phần tử html*/
                    render: function (data) {
                        return `<i id=${data} class="bi bi-plus-circle btn-add"/>`;
                    }
                }
            ]
        })
    );
});
var arrayCard = [];
/*thực hiện click vào class="btn-add"*/
$(document).on('click', '.btn-add', function () {
    var id = this.id
    console.log(arrayCard.includes(id));
    
    var url = `/api/app/product/${id}/product`
    var quantity = 1
    $.get(url, (res) => {
        var html = `
                    <tr id="myTableRow${res.id}">
                        <td>${res.name}</td>
                        <td> ${res.unitPrice}</td>
                        <td>
                              <i class="bi bi-dash-circle" id="${res.id}" onclick=" Quantity('dow',this.id)" style="width: 20%"></i>
                              <input id="quantity${res.id}" value=${quantity} style="width: 60%" />
                              <i id="${res.id}" class="bi bi-plus-circle" onclick="Quantity('up',this.id)" style="width: 20%"></i>
                        </td>
                        <td>
                            <h3 id="Sum"> sum </h3>
                        </td>
                        <td>
                            <i class="bi bi-x-circle-fill" id="${res.id}" onclick="Delete(this.id)"></i>
                        </td>
                    </tr>`

        if (!arrayCard.includes(id)) {
            arrayCard.push(id);
            $('#td').append(html);
        } else {
            let value = parseInt($("#quantity" + id).val()) + 1;
            $("#quantity" + id).val(value);
        }
    })        
})
function Quantity(type, id) {
    let value = $("#quantity" + id).val();
    if (type === 'up') {
        value++;

    } else {

        value--;
    }
    if (value < 0) {
        value = 0;
        abp.message.confirm('Are you sure to delete the "admin" role?')
            .then(function (confirmed) {
                if (confirmed) {
                    Delete(id);
                }
            });
    }
    $("#quantity" + id).val(value)
    $('#h3').text(val)
}

/*xóa dòng*/
function Delete(id) {
    $('#myTableRow' + id).remove();
    /*Lấy vị trí của id trong arry*/
    var index = arrayCard.indexOf(id);
    /*xóa phần tử tại vị trí và xóa 1 phần tử*/
    arrayCard.splice(index, 1);
}



