//...............Start price.................//

function loadData() {
    $.ajax({
        url: "/beauty/price",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.SubTitle}</td>`;
                html += `<td>${item.Makeup}</td>`;
                html += `<td>${item.Description}</td>`;
                html += `<td>${item.Prices}</td>`;
                html += `<td>
                             <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetPrice(${item.ID})"><i class="fa fa-edit"></i></a>
                             <a href="#" onclick="DelPrice(${item.ID})"><i class="fa fa-trash"></i></a>
                             </td>`;
                html += '</tr>';
            });
            $('#pricelist').html(html);
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
loadData();
function Clear() {
    $('form#priceForm').trigger("reset");
    $("#ID").val(0);
}
function GetPrice(id) {
    $.ajax({
        url: `/beauty/price?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#Price").val(result[0].Prices);
            $("#SubTitle").val(result[0].SubTitle);
            $("#Makeup").val(result[0].Makeup);
            $("#Description").val(result[0].Description);
            $("#ID").val(result[0].ID);
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
function submitPrice() {
    var price = {
        ID: $('#ID').val(),
        SubTitle: $('#SubTitle').val(),
        Makeup: $('#Makeup').val(),
        Prices: $('#Price').val(),
        Description: $('#Description').val()
    };
    $.ajax({
        url: "/beauty/price",
        data: JSON.stringify(price),
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            toastr.success(result.message, 'Success');
            $('[data-dismiss="modal"]').trigger('click');
            loadData();
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
    return false;
}

function DelPrice(id) {
    showConfirmationDialog("confirmDelete(" + id + ")", "cancelDelete");
}
function confirmDelete(id) {

    $.ajax({
        url: `/beauty/deleteprice?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            toastr.success(result.message, 'Success');
            loadData();
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
//...............End price.................//
