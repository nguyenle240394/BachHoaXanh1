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

/*ẩn nút save*/
$(document).ready(() => {
    if (arrayCard.length == 0) {
        document.getElementById("save").hidden = true;
        document.getElementById("Sumh2").hidden = true;
    }
});

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
                              <i class="bi bi-dash-circle" id="${res.id}" onclick=" Quantity('dow',this.id, ${res.unitPrice})" style="width: 20%"></i>
                              <input id="quantity${res.id}" value=${quantity} style="width: 60%" />
                              <i id="${res.id}" class="bi bi-plus-circle" onclick="Quantity('up',this.id,${res.unitPrice})" style="width: 20%"></i>
                        </td>
                        <td>
                            <span id="span${res.id}">
                                ${res.unitPrice}
                            </span>
                        </td>
                        <td>
                            <i class="bi bi-x-circle-fill" id="${res.id}" onclick="Delete(this.id)"></i>
                        </td>
                    </tr>`
        if (quantity == 1) {
            $(`#span${res.id}`).text("test");
        }
        
        /*kiểm tra id đã có trong arry chưa*/
        if (!arrayCard.includes(id)) {
            /*thêm giá trị id vào arry*/
            arrayCard.push(id);
            $('#td').append(html);
        } else {
            /*chuyển giá trị value thành int*/
            let value = parseInt($("#quantity" + id).val()) + 1;
            /*xử lý trường hợp sản phẩm đã có thì cộng giá trị lên 1*/
            $("#quantity" + id).val(value);
        }
    })
    document.getElementById("save").hidden = false;
    document.getElementById("Sumh2").hidden = false;
})
function Quantity(type, id, unitPrice) {

    calc_total();

    /*lấy giá trị ô input tại id của input*/
    let value = $("#quantity" + id).val();
    if (type === 'up') {
        value++;
        var sum = unitPrice * value;
        $("#span" + id).text(sum);
    } else {
        value--;
        var sum = unitPrice * value;
        $("#span" + id).text(sum);
    }
    if (value < 0) {
        value = 0;
        $("#span" + id).text("0");
        /*thông báo chuyển đến hàm xóa row*/
        abp.message.confirm('Are you sure to delete')
            .then(function (confirmed) {
                if (confirmed) {
                    Delete(id);
                }
            });
        calc_total();
    }
    /*gán giá trị cho ô input*/
    $("#quantity" + id).val(value)
}

function calc_total() {
    var sum = 0;
    $("[id^=span]").each(() => {
        /*sum = sum + parseFloat($(this).text());
        console.log(sum);*/
        var id = this.id;
        console.log(id);
    });
    /*$("#rsSum").text("Sum: " + sum);*/
};



/*xóa dòng*/
function Delete(id) {
    $('#myTableRow' + id).remove();
    /*Lấy vị trí của id trong arry*/
    var index = arrayCard.indexOf(id);
    /*xóa phần tử tại vị trí và xóa 1 phần tử*/
    arrayCard.splice(index, 1);
    if (arrayCard.length == 0) {
        /*load lại trang*/
        location.reload();
        return;
    }
}